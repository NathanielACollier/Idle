﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.IO;
using ILEditor.Classes;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ILEditor.Classes.LanguageTools;
using System.Threading;
using ICSharpCode.AvalonEdit;
using System.Xml;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Search;
using FindReplace;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Windows.Media;
using ILEditor.Forms;

namespace ILEditor.UserTools
{
    public enum ILELanguage
    {
        None,
        CL,
        CPP,
        RPG,
        SQL,
        COBOL
    }

    public partial class SourceEditor : UserControl
    {
        private TextEditor textEditor = null;
        private ILELanguage Language;
        private int RcdLen;

        public SourceEditor(String LocalFile, ILELanguage Language = ILELanguage.None, int RecordLength = 0)
        {
            InitializeComponent();

            //https://www.codeproject.com/Articles/161871/Fast-Colored-TextBox-for-syntax-highlighting

            this.Language = Language;
            this.RcdLen = RecordLength;

            textEditor = new TextEditor();
            textEditor.ShowLineNumbers = true;
            textEditor.Text = File.ReadAllText(LocalFile);

            textEditor.FontFamily = new System.Windows.Media.FontFamily(IBMi.CurrentSystem.GetValue("FONT"));
            textEditor.FontSize = float.Parse(IBMi.CurrentSystem.GetValue("ZOOM"));

            textEditor.TextChanged += TextEditor_TextChanged;
            textEditor.TextArea.Caret.PositionChanged += TextEditorTextAreaCaret_PositionChanged;
            textEditor.GotFocus += TextEditor_GotFocus;

            textEditor.Options.ConvertTabsToSpaces = true;
            textEditor.Options.EnableTextDragDrop = false;
            textEditor.Options.IndentationSize = int.Parse(IBMi.CurrentSystem.GetValue("INDENT_SIZE"));
            textEditor.Options.ShowSpaces = (IBMi.CurrentSystem.GetValue("SHOW_SPACES") == "true");
            textEditor.Options.HighlightCurrentLine = (IBMi.CurrentSystem.GetValue("HIGHLIGHT_CURRENT_LINE") == "true");

            textEditor.Options.AllowScrollBelowDocument = true;
            
            if (this.RcdLen > 0)
            {
                textEditor.Options.ShowColumnRuler = true;
                textEditor.Options.ColumnRulerPosition = this.RcdLen;
            }

            //SearchPanel.Install(textEditor);
            SearchReplacePanel.Install(textEditor);

            string lang = "";
            bool DarkMode = (Program.Config.GetValue("darkmode") == "true");

            if (DarkMode)
                lang += "dark";
            else
                lang += "light";

            switch (Language)
            {
                case ILELanguage.RPG:
                    lang += "RPG";
                    break;
                case ILELanguage.SQL:
                    lang += "SQL";
                    break;
                case ILELanguage.CPP:
                    lang += "CPP";
                    break;
                case ILELanguage.CL:
                    lang += "CL";
                    break;
                case ILELanguage.COBOL:
                    lang += "COBOL";
                    break;
                case ILELanguage.None:
                    lang = "";
                    break;
            }

            if (DarkMode)
            {
                textEditor.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#1E1E1E");
                textEditor.Foreground = System.Windows.Media.Brushes.White;
            }

            if (lang != "")
                using (Stream s = new MemoryStream(Encoding.ASCII.GetBytes(Properties.Resources.ResourceManager.GetString(lang))))
                    using (XmlTextReader reader = new XmlTextReader(s))
                        textEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);

            ElementHost host = new ElementHost();
            host.Dock = DockStyle.Fill;
            host.Child = textEditor;
            this.Controls.Add(host);
        }

        public void SetReadOnly(bool ReadOnly)
        {
            textEditor.IsReadOnly = ReadOnly;
        }

        public string GetText()
        {
            return textEditor.Text;
        }

        public void GotoLine(int line, int col)
        {
            line++; col++;
            if (line > 0)
            {
                int pos = textEditor.Document.GetOffset(line, col);
                textEditor.ScrollToLine(line);
                textEditor.CaretOffset = pos;
                textEditor.Focus();
            }
        }

        public void Zoom(float change)
        {
            if (textEditor.FontSize + change > 5 && textEditor.FontSize + change < 100)
            {
                textEditor.FontSize += change;
                IBMi.CurrentSystem.SetValue("ZOOM", textEditor.FontSize.ToString());
            }
        }

        private Control GetParent()
        {
            return this.Parent;
        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            if (!GetParent().Text.EndsWith("*"))
            {
                GetParent().Text += "*";
            }
        }
        
        private void TextEditorTextAreaCaret_PositionChanged(object sender, EventArgs e)
        {
            DocumentLine line = textEditor.Document.GetLineByOffset(textEditor.CaretOffset);
            int col = textEditor.CaretOffset - line.Offset;
            Editor.TheEditor.SetColumnLabel($"Ln: {line.LineNumber} Col: {col}");
        }

        private void TextEditor_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            Editor.TheEditor.LastEditing = this;
        }

        public void SaveAs()
        {
            if (!GetParent().Text.EndsWith("*"))
            {
                SaveAs SaveAsWindow = new SaveAs();
                SaveAsWindow.ShowDialog();
                if (SaveAsWindow.Success)
                {
                    Member MemberInfo = (Member)this.Tag;
                    if (!MemberInfo._IsBeingSaved)
                    {
                        MemberInfo._IsBeingSaved = true;

                        Editor.TheEditor.SetStatus("Saving " + SaveAsWindow.Mbr + "..");
                        Thread gothread = new Thread((ThreadStart)delegate
                        {
                            bool UploadResult = IBMiUtils.UploadMember(MemberInfo.GetLocalFile(), SaveAsWindow.Lib, SaveAsWindow.Spf, SaveAsWindow.Mbr);
                            if (UploadResult == false)
                                MessageBox.Show("Failed to upload to " + SaveAsWindow.Mbr + ".");

                            this.Invoke((MethodInvoker)delegate
                            {
                                Editor.TheEditor.SetStatus(SaveAsWindow.Mbr + " " + (UploadResult ? "" : "not ") + "saved.");
                            });

                            MemberInfo._IsBeingSaved = false;
                        });

                        gothread.Start();
                    }
                }
            }
            else
            {
                MessageBox.Show("You must save the source before you can Save-As.");
            }
        }

        public void Save()
        {
            Member MemberInfo = (Member)this.Tag;
            if (MemberInfo.IsEditable())
            {
                if (!MemberInfo._IsBeingSaved)
                {
                    MemberInfo._IsBeingSaved = true;

                    Editor.TheEditor.SetStatus("Saving " + MemberInfo.GetMember() + "..");
                    Thread gothread = new Thread((ThreadStart)delegate
                    {

                        this.Invoke((MethodInvoker)delegate
                        {
                            File.WriteAllText(MemberInfo.GetLocalFile(), this.GetText());
                        });
                        bool UploadResult = IBMiUtils.UploadMember(MemberInfo.GetLocalFile(), MemberInfo.GetLibrary(), MemberInfo.GetObject(), MemberInfo.GetMember());
                        if (UploadResult == false)
                        {
                            //MessageBox.Show("Failed to upload to " + MemberInfo.GetMember() + ".");
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (GetParent().Text.EndsWith("*"))
                                    GetParent().Text = GetParent().Text.Substring(0, GetParent().Text.Length - 1);
                            });
                        }

                        this.Invoke((MethodInvoker)delegate
                        {
                            Editor.TheEditor.SetStatus(MemberInfo.GetMember() + " " + (UploadResult ? "" : "not ") + "saved.");
                        });

                        MemberInfo._IsBeingSaved = false;
                    });

                    gothread.Start();
                }

            }
            else
            {
                MessageBox.Show("This file is readonly.");
            }
        }

        #region RPG

        public void ConvertSelectedRPG()
        {
            if (textEditor.SelectedText == "")
            {
                MessageBox.Show("Please highlight the code you want to convert and then try the conversion again.", "Fixed-To-Free", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string[] lines = textEditor.SelectedText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                string freeForm = "";

                for (int i = 0; i < lines.Length; i++)
                {
                    freeForm = RPGFree.getFree(lines[i]);
                    if (freeForm != "")
                    {
                        lines[i] = freeForm;
                    }
                }

                textEditor.SelectedText = String.Join(Environment.NewLine, lines);
            }

        }
        #endregion

        #region CL

        public void FormatCL()
        {
            string[] Lines = textEditor.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
            textEditor.Clear();
            int length = (RcdLen > 0 ? RcdLen : 80);
            textEditor.AppendText(String.Join(Environment.NewLine, CLFile.CorrectLines(Lines, length)));
        }
        #endregion
    }
}
