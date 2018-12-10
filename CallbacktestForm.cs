// Copyright (c) 2014-2018, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace callbacktest_plugin
{
    using System;
    using System.Windows.Forms;
    using Elskom.Generic.Libs;

    public partial class CallbacktestForm : Form
    {
        private int callbacksetting1;
        private int callbacksetting1Temp;

        public CallbacktestForm() => this.InitializeComponent();

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBox1.Checked == true)
            {
                this.callbacksetting1Temp = 1;
            }
            else if (this.callbacksetting1Temp > 0)
            {
                this.callbacksetting1Temp = 0;
            }
        }

        private void CallbacktestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsFile.Settingsxml.ReopenFile();
            if (this.callbacksetting1 != this.callbacksetting1Temp)
            {
                this.callbacksetting1 = this.callbacksetting1Temp;
                SettingsFile.Settingsxml.Write("ShowTestMessages", this.callbacksetting1.ToString());
            }

            SettingsFile.Settingsxml.Save();
        }

        private void CallbacktestForm_Load(object sender, EventArgs e)
        {
            this.callbacksetting1 = 0;
            this.callbacksetting1Temp = 0;
            SettingsFile.Settingsxml.ReopenFile();
            int.TryParse(SettingsFile.Settingsxml.Read("ShowTestMessages"), out this.callbacksetting1);
            if (this.callbacksetting1 > 0)
            {
                this.CheckBox1.Checked = true;
            }
        }

        private void Label1_Click(object sender, EventArgs e) => this.CheckBox1.Checked = this.CheckBox1.Checked ? false : true;
    }
}
