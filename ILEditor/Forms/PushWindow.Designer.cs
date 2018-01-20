﻿namespace ILEditor.Forms
{
    partial class PushWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Creating source-physical files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Deleting remote members", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Adding remote members", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Uploading local members", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Creating source-physical files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Deleting remote members", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Adding remote members", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PushWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.lib = new System.Windows.Forms.TextBox();
            this.pushButton = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.memberLog = new System.Windows.Forms.ListView();
            this.fetch = new System.Windows.Forms.Button();
            this.commandLog = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.runCommands = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Library";
            // 
            // lib
            // 
            this.lib.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lib.Location = new System.Drawing.Point(183, 13);
            this.lib.MaxLength = 10;
            this.lib.Name = "lib";
            this.lib.Size = new System.Drawing.Size(224, 20);
            this.lib.TabIndex = 8;
            // 
            // pushButton
            // 
            this.pushButton.Enabled = false;
            this.pushButton.Location = new System.Drawing.Point(332, 390);
            this.pushButton.Name = "pushButton";
            this.pushButton.Size = new System.Drawing.Size(75, 23);
            this.pushButton.TabIndex = 14;
            this.pushButton.Text = "Push";
            this.pushButton.UseVisualStyleBackColor = true;
            this.pushButton.Click += new System.EventHandler(this.pushButton_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(12, 390);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 15;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // memberLog
            // 
            this.memberLog.CheckBoxes = true;
            listViewGroup1.Header = "Creating source-physical files";
            listViewGroup1.Name = null;
            listViewGroup2.Header = "Deleting remote members";
            listViewGroup2.Name = null;
            listViewGroup3.Header = "Adding remote members";
            listViewGroup3.Name = null;
            listViewGroup4.Header = "Uploading local members";
            listViewGroup4.Name = null;
            this.memberLog.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.memberLog.Location = new System.Drawing.Point(12, 225);
            this.memberLog.Name = "memberLog";
            this.memberLog.Size = new System.Drawing.Size(395, 159);
            this.memberLog.TabIndex = 16;
            this.memberLog.UseCompatibleStateImageBehavior = false;
            this.memberLog.View = System.Windows.Forms.View.List;
            // 
            // fetch
            // 
            this.fetch.Location = new System.Drawing.Point(261, 39);
            this.fetch.Name = "fetch";
            this.fetch.Size = new System.Drawing.Size(146, 20);
            this.fetch.TabIndex = 10;
            this.fetch.Text = "Fetch Local Member List";
            this.fetch.UseVisualStyleBackColor = true;
            this.fetch.Click += new System.EventHandler(this.fetch_Click);
            // 
            // commandLog
            // 
            listViewGroup5.Header = "Creating source-physical files";
            listViewGroup5.Name = null;
            listViewGroup6.Header = "Deleting remote members";
            listViewGroup6.Name = null;
            listViewGroup7.Header = "Adding remote members";
            listViewGroup7.Name = null;
            this.commandLog.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6,
            listViewGroup7});
            this.commandLog.Location = new System.Drawing.Point(12, 79);
            this.commandLog.Name = "commandLog";
            this.commandLog.Size = new System.Drawing.Size(395, 118);
            this.commandLog.TabIndex = 17;
            this.commandLog.UseCompatibleStateImageBehavior = false;
            this.commandLog.View = System.Windows.Forms.View.Tile;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Uploading Members";
            // 
            // runCommands
            // 
            this.runCommands.AutoSize = true;
            this.runCommands.Checked = true;
            this.runCommands.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runCommands.Enabled = false;
            this.runCommands.Location = new System.Drawing.Point(12, 56);
            this.runCommands.Name = "runCommands";
            this.runCommands.Size = new System.Drawing.Size(115, 17);
            this.runCommands.TabIndex = 19;
            this.runCommands.Text = "Creation / Deletion";
            this.runCommands.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "This will overwrite any remote sources.";
            // 
            // PushWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 425);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.runCommands);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandLog);
            this.Controls.Add(this.memberLog);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.pushButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fetch);
            this.Controls.Add(this.lib);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PushWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Push to Source-Physical File";
            this.Load += new System.EventHandler(this.PushWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lib;
        private System.Windows.Forms.Button pushButton;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ListView memberLog;
        private System.Windows.Forms.Button fetch;
        private System.Windows.Forms.ListView commandLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox runCommands;
        private System.Windows.Forms.Label label3;
    }
}