﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ILEditor.Classes;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;

namespace ILEditor.UserTools
{
    public partial class ObjectBrowse : DockContent
    {
        public ObjectBrowse()
        {
            InitializeComponent();
            this.Text = "Object Browser";
        }

        private readonly Dictionary<string, int> IconKeys = new Dictionary<string, int>()
        {
            { "*PGM", 0 },
            { "*SRVPGM", 1 },
            { "*MODULE", 2 },
            { "*BNDDIR", 3 }
        };
        private List<ListViewItem> curItems = new List<ListViewItem>();
        private ILEObject[] Objects;
        public void UpdateListing(string Lib)
        {
            Thread gothread = new Thread((ThreadStart)delegate
            {
                
                ListViewItem curItem;

                curItems.Clear();

                this.Invoke((MethodInvoker)delegate
                {
                    objectList.Items.Clear();
                    objectList.Items.Add(new ListViewItem("Loading...", 2));
                });

                Objects = IBMiUtils.GetObjectList(Lib, "*PGM *SRVPGM *MODULE *BNDDIR");

                this.Invoke((MethodInvoker)delegate
                {
                    objectList.Items.Clear();
                });

                if (Objects != null)
                {
                    foreach (ILEObject Object in Objects)
                    {
                        curItem = new ListViewItem(new string[4] { Object.Name, Object.Extension, Object.Type, Object.Text }, 0);
                        curItem.Tag = Object;

                        if (IconKeys.ContainsKey(Object.Type))
                            curItem.ImageIndex = IconKeys[Object.Type];
                        else
                            curItem.ImageIndex = -1;

                        curItems.Add(curItem);
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        objectList.Items.AddRange(curItems.ToArray());
                        programcount.Text = Objects.Length.ToString() + " object" + (Objects.Length == 1 ? "" : "s");
                    });
                }
                else
                {

                    this.Invoke((MethodInvoker)delegate
                    {
                        objectList.Items.Add(new ListViewItem("No objects found!", 1));
                        programcount.Text = "0 objects";
                    });
                }
            });
            gothread.Start();
        }

        private void fetchButton_Click(object sender, EventArgs e)
        {
            library.Text = library.Text.Trim();

            if (!IBMiUtils.IsValueObjectName(library.Text))
            {
                MessageBox.Show("Library name is not valid.");
                return;
            }

            this.Text = library.Text + " [Listing]";
            UpdateListing(library.Text);
        }

        #region rightclick
        private ILEObject currentRightClick;
        private void objectList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (objectList.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    currentRightClick = (ILEObject)objectList.FocusedItem.Tag;
                    objectRightClick.Show(Cursor.Position);
                }
            }
        }

        private void objectRightClick_Opening(object sender, CancelEventArgs e)
        {
            if (currentRightClick != null)
            {
                objectInformationToolStripMenuItem.Enabled = true;
                openSourceToolStripMenuItem.Enabled = false;
                updateToolStripMenuItem.Enabled = false;

                switch (currentRightClick.Type) {
                    case "*BNDDIR":
                        openSourceToolStripMenuItem.Enabled = true;
                        break;
                    case "*PGM":
                    case "*SRVPGM":
                        updateToolStripMenuItem.Enabled = true;
                        break;
                    default:
                        openSourceToolStripMenuItem.Enabled = (currentRightClick.SrcMbr != "");
                        break;
                }
            }
        }

        private void openSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentRightClick != null)
            {
                switch (currentRightClick.Type)
                {
                    case "*BNDDIR":
                        Editor.TheEditor.AddTool(new BindingDirectory(currentRightClick.Library, currentRightClick.Name));
                        break;
                    default:
                        Editor.OpenSource(new RemoteSource("", currentRightClick.SrcLib, currentRightClick.SrcSpf, currentRightClick.SrcMbr, currentRightClick.Extension));
                        break;
                }
            }
        }

        private void objectInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentRightClick != null)
            {
                new Forms.ObjectInformation(currentRightClick).Show();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentRightClick != null)
            {
                new Forms.UpdateProgram(currentRightClick, Objects).Show();
            }
        }
        #endregion

    }
}
