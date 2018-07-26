// Copyright (c) 2014-2018, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace callbacktest_plugin
{
    public partial class CallbacktestForm : System.Windows.Forms.Form
    {
        public CallbacktestForm()
        {
            InitializeComponent();
        }
        internal int callbacksetting1;
        internal int callbacksetting1_temp;

        private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            callbacksetting1_temp = CheckBox1.Checked ? 1 : callbacksetting1_temp > 0 ? 0 : callbacksetting1_temp;
        }

        private void CallbacktestForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Els_kom_Core.Classes.SettingsFile.Settingsxml.ReopenFile();
            callbacksetting1 = callbacksetting1 != callbacksetting1_temp ? callbacksetting1_temp : callbacksetting1;
            Els_kom_Core.Classes.SettingsFile.Settingsxml.Write("ShowTestMessages", callbacksetting1.ToString());
            Els_kom_Core.Classes.SettingsFile.Settingsxml.Save();
        }

        private void CallbacktestForm_Load(object sender, System.EventArgs e)
        {
            callbacksetting1 = 0;
            callbacksetting1_temp = 0;
            Els_kom_Core.Classes.SettingsFile.Settingsxml.ReopenFile();
            int.TryParse(Els_kom_Core.Classes.SettingsFile.Settingsxml.Read("ShowTestMessages"), out callbacksetting1);
            // set to true if callbacksetting1 > 0 is evaluated to true.
            CheckBox1.Checked = callbacksetting1 > 0;
        }
    }
}
