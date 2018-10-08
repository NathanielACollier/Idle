﻿using ILEditor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILEditor.Forms.CompileOptionForms
{
    public partial class EditCommand : Form
    {
        public EditCommand(string Type = "", string Command = "")
        {
            InitializeComponent();

            types.Items.AddRange(IBMi.CurrentSystem.GetValue("CMPTYPES").Split('|'));
            if (Type != "")
            {
                types.Text = Type;
                types.Enabled = false;
            }

            name.Text = Command;
            if (Command != "")
                name.Enabled = false;

            command_qsys.Text = IBMi.CurrentSystem.GetValue(Command);
            command_ifs.Text = IBMi.CurrentSystem.GetValue(Command + "_IFS");
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (types.Text == "")
            {
                MessageBox.Show("Invalid member type.");
                types.Focus();
                return;
            }

            if (name.Text.Trim() == "")
            {
                MessageBox.Show("Cannot have a blank name.");
                return;
            }

            List<string> Commands = IBMi.CurrentSystem.GetValue("TYPE_" + types.Text).Split('|').ToList();
            if (!Commands.Contains(name.Text))
            {
                Commands.Add(name.Text);
                IBMi.CurrentSystem.SetValue("TYPE_" + types.Text, String.Join("|", Commands));
            }

            IBMi.CurrentSystem.SetValue(name.Text.Trim(), command_qsys.Text.Trim());
            IBMi.CurrentSystem.SetValue(name.Text.Trim() + "_IFS", command_ifs.Text.Trim());

            this.Close();
        }
    }
}
