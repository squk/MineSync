using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace MineSyncer
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            savepathText.Text = Properties.Settings.Default.savesPath;
            saveOverride.Checked = Properties.Settings.Default.overrideSave;
            intervalCheck.Checked = Properties.Settings.Default.intervalCheck;
            chkStartUp.Checked = Properties.Settings.Default.chkStartUp;
            if (saveOverride.Checked == true)
            {
                savepathText.Enabled = true;
                savepathText.Text = Properties.Settings.Default.savesPath;
            }
            else
            {
                savepathText.Enabled = false;
                savepathText.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\.minecraft\saves";
            }
        }

        private void saveOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (saveOverride.Checked == true)
            {
                savepathText.Enabled = true;
                savepathText.Text = "";
            }
            else
            {
                savepathText.Enabled = false;
                savepathText.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\.minecraft\saves";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveOverride.Checked)
            {
                if (Directory.Exists(savepathText.Text))
                {
                    Properties.Settings.Default.savesPath = savepathText.Text;
                    Properties.Settings.Default.overrideSave = true;
                }
            }
            else
            {
                Properties.Settings.Default.savesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\.minecraft\saves";
                Properties.Settings.Default.overrideSave = false;
            }
            Properties.Settings.Default.intervalCheck = intervalCheck.Checked;
            SetStartup();
            Properties.Settings.Default.Save();
            //MessageBox.Show("A restart of MineSync is recommended");
            DialogResult dialogResult = MessageBox.Show("A restart of MineSync is recommended. Restart now?", "Restart?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Restart();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (chkStartUp.Checked)
            {
                rk.SetValue("MineSync", Application.ExecutablePath.ToString());
                Properties.Settings.Default.chkStartUp = true;
            }
            else
            {
                rk.DeleteValue("MineSync", false);
                Properties.Settings.Default.chkStartUp = false;
            }

        }
    }
}
