﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ILEditor.Classes;

namespace ILEditor.UserTools
{
    public partial class ErrorListing : UserControl
    {
        private string Library;
        private string Object;

        public ErrorListing(string Lib = "", string Obj = "")
        {
            InitializeComponent();
            Library = Lib;
            Object = Obj;
        }
        
        private void ErrorListing_Load(object sender, EventArgs e)
        {
            this.Parent.Text = "Error Listing";

            Thread gothread = new Thread((ThreadStart)delegate
            {
                ErrorHandle.getErrors(Library, Object);
                publishErrors();
            });
            gothread.Start();
        }

        public void publishErrors()
        {
            Invoke((MethodInvoker)delegate
            {
                int totalErrors = 0;
                TreeNode curNode;

                if (ErrorHandle.WasSuccessful())
                {
                    treeView1.Nodes.Clear(); //Clear out the nodes

                    //Add the errors
                    TreeNode curErr;
                    foreach (int fileid in ErrorHandle.getFileIDs())
                    {
                        curNode = new TreeNode(ErrorHandle.getFilePath(fileid));
                        foreach (LineError error in ErrorHandle.getErrors(fileid))
                        {
                            if (error.getSev() >= 20)
                            {
                                totalErrors += 1;
                                curErr = curNode.Nodes.Add((error.getCode() == "" ? "" : error.getCode() + ": ") + error.getData().Trim() + " (" + error.getLine().ToString() + ")");

                                if (error.getCode() != "")
                                    curErr.Tag = error.getLine().ToString() + ',' + error.getColumn().ToString();

                                curErr.ImageIndex = 1;
                                curErr.SelectedImageIndex = 1;
                            }
                        }

                        //Only add a node if there is something to display
                        if (curNode.Nodes.Count > 0)
                        {
                            curNode.ImageIndex = 0;
                            curNode.SelectedImageIndex = 0;
                            treeView1.Nodes.Add(curNode);
                        }
                    }

                    if (totalErrors == 0)
                    {
                        treeView1.Nodes.Add(new TreeNode("No errors found for " + Library + "/" + Object + ".", 2, 2));
                    }

                    if (treeView1.Nodes.Count <= 1)
                    {
                        treeView1.ExpandAll();
                    }  
                }

                toolStripStatusLabel1.Text = "Total errors: " + totalErrors.ToString();
                toolStripStatusLabel2.Text = ErrorHandle.doName();
                toolStripStatusLabel3.Text = DateTime.Now.ToString("h:mm:ss tt");
            });
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) { }
            else
            {
                string[] data = e.Node.Tag.ToString().Split(',');
                int line, col;
                string error;

                line = int.Parse(data[0]) - 1;
                col = int.Parse(data[1]);
                error = e.Node.Text;
                if (col > 0) col--;

                onSelectError(e.Node.Parent.Text, line, col, error);
            }
        }

        private void onSelectError(string File, int Line, int Col, string ErrorText)
        {
            OpenTab theTab = Editor.TheEditor.EditorContains(File);

            if (theTab != null)
            {
                Editor.TheEditor.SwitchToTab(theTab.getSide(), theTab.getIndex());
                SourceEditor SourceEditor = Editor.TheEditor.GetTabEditor(theTab);

                SourceEditor.Focus();
                SourceEditor.GotoLine(Line, Col);
            }
            else
            {
                MessageBox.Show("Unable to open error. Please open the source manually first and then try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
