// Copyright (c) 2014-2018, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace callbacktest_plugin
{
    using System.Windows.Forms;
    using Elskom.Generic.Libs;

    public class Callbacktest_plugin : ICallbackPlugin
    {
        /// <inheritdoc/>
        public string PluginName => "Callback Test Plugin";

        /// <inheritdoc/>
        public bool SupportsSettings => true;

        /// <inheritdoc/>
        public bool ShowModal => true;

        /// <inheritdoc/>
        public Form SettingsWindow => new CallbacktestForm();

        /// <inheritdoc/>
        public void TestModsCallback()
        {
            SettingsFile.Settingsxml.ReopenFile();
            int.TryParse(SettingsFile.Settingsxml.Read("ShowTestMessages"), out var callbacksetting1);
            if (callbacksetting1 > 0)
            {
                MessageBox.Show(
                    "Testing this callback interface.",
                    "Info!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
