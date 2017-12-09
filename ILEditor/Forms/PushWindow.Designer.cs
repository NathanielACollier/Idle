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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Deleting remote members", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Adding remote members", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Uploading local members", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PushWindow));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fetch = new System.Windows.Forms.Button();
            this.spf = new System.Windows.Forms.TextBox();
            this.lib = new System.Windows.Forms.TextBox();
            this.pushButton = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.memberLog = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Source-Physical File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Library";
            // 
            // fetch
            // 
            this.fetch.Location = new System.Drawing.Point(220, 65);
            this.fetch.Name = "fetch";
            this.fetch.Size = new System.Drawing.Size(146, 20);
            this.fetch.TabIndex = 10;
            this.fetch.Text = "Fetch Local Member List";
            this.fetch.UseVisualStyleBackColor = true;
            this.fetch.Click += new System.EventHandler(this.fetch_Click);
            // 
            // spf
            // 
            this.spf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.spf.Location = new System.Drawing.Point(142, 39);
            this.spf.MaxLength = 10;
            this.spf.Name = "spf";
            this.spf.Size = new System.Drawing.Size(224, 20);
            this.spf.TabIndex = 9;
            // 
            // lib
            // 
            this.lib.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lib.Location = new System.Drawing.Point(142, 13);
            this.lib.MaxLength = 10;
            this.lib.Name = "lib";
            this.lib.Size = new System.Drawing.Size(224, 20);
            this.lib.TabIndex = 8;
            // 
            // pushButton
            // 
            this.pushButton.Enabled = false;
            this.pushButton.Location = new System.Drawing.Point(291, 350);
            this.pushButton.Name = "pushButton";
            this.pushButton.Size = new System.Drawing.Size(75, 23);
            this.pushButton.TabIndex = 14;
            this.pushButton.Text = "Push";
            this.pushButton.UseVisualStyleBackColor = true;
            this.pushButton.Click += new System.EventHandler(this.pushButton_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(12, 350);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 15;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // memberLog
            // 
            listViewGroup1.Header = "Deleting remote members";
            listViewGroup1.Name = null;
            listViewGroup2.Header = "Adding remote members";
            listViewGroup2.Name = null;
            listViewGroup3.Header = "Uploading local members";
            listViewGroup3.Name = null;
            this.memberLog.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.memberLog.Location = new System.Drawing.Point(12, 91);
            this.memberLog.Name = "memberLog";
            this.memberLog.Size = new System.Drawing.Size(353, 253);
            this.memberLog.TabIndex = 16;
            this.memberLog.UseCompatibleStateImageBehavior = false;
            this.memberLog.View = System.Windows.Forms.View.Tile;
            // 
            // PushWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 385);
            this.Controls.Add(this.memberLog);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.pushButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fetch);
            this.Controls.Add(this.spf);
            this.Controls.Add(this.lib);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PushWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Push to Source-Physical File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fetch;
        private System.Windows.Forms.TextBox spf;
        private System.Windows.Forms.TextBox lib;
        private System.Windows.Forms.Button pushButton;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ListView memberLog;
    }
}