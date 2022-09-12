using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScreenSaver
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();

            okButton.Click += (s, e) =>
            {
                SaveSettings();
                this.Close();
            };

            cancelButton.Click += (s, e) =>
            {
                this.Close();
            };
        }

        private void SaveSettings()
        {
            // Create or get existing Registry subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MyScreenSaver");

            key.SetValue("text", textBox.Text);
        }

        private void LoadSettings()
        {
            // Get the value stored in the Registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MyScreenSaver");
            if (key == null)
                textBox.Text = DateTime.Now.ToLongTimeString();
            else
                textBox.Text = (string)key.GetValue("text");
        }

    }
}
