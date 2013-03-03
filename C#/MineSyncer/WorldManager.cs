using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Security.Cryptography;
using System.IO;

namespace MineSyncer
{
    public partial class WorldManager : Form
    {
        List<string> worldIDs = new List<string>();
        List<string> worldNames = new List<string>();
        List<string> worldDates = new List<string>();
        List<string> worldShared = new List<string>();


        private Form1 mainForm = null;
        public WorldManager(Form callingForm)
        {
            mainForm = callingForm as Form1; 
            InitializeComponent();
            WebClient wc = new WebClient();
            string username = Properties.Settings.Default.username;
            string hash = CalculateMD5Hash("manageWorlds" + username + "RANDOMSTRING");
            //MessageBox.Show(hash);
            string uri = "http://URL/manageWorlds.php";
            string param = "?type=0" + "&username=" + username + "&hash=" + hash;
            string url = uri + param;
            byte[] response = wc.DownloadData(url);
            string results = Encoding.ASCII.GetString(response);
            string[] fullWorlds = results.Split('\n');
            
            for (int x = 0; x < fullWorlds.Length-1;x++ )
            {
                string[] splitWorld = fullWorlds[x].Split(',');
                worldIDs.Add(splitWorld[0]);
                worldNames.Add(splitWorld[1]);
                worldDates.Add(splitWorld[2]);
                worldShared.Add(splitWorld[3]);
            }
            DomainUpDown.DomainUpDownItemCollection items = this.worldsUD.Items;
            for (int i = 0; i < worldNames.Count; i++)
            {
                items.Add(worldNames[i]);
            }
            worldsUD.Text = worldNames[0];
        }

        private void WorldManager_Load(object sender, EventArgs e)
        {
            
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        bool changingWorlds = false;
        private void worldsUD_SelectedItemChanged(object sender, EventArgs e)
        {
            changingWorlds = true;
            int index = worldNames.IndexOf(worldsUD.Text);
            dateLabel.Text= worldDates[index];
            if (worldShared[index] == "0")
            {
                downloadCheck.Checked = false;
                dlButton.Enabled = false;
            }
            else
            {
                downloadCheck.Checked = true;
                dlButton.Enabled = true;
            }
            changingWorlds = false;
            string savePath = Properties.Settings.Default.savesPath;
            if (Properties.Settings.Default.savesPath != "")
            {
                savePath = Properties.Settings.Default.savesPath;
            }
            else
            {
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\.minecraft\saves";
            }
            //string worldDat = savePath + @"\" + worldNames[index] + @"\level.dat";
            
        }

        private void dlButton_Click(object sender, EventArgs e)
        {
            int index = worldNames.IndexOf(worldsUD.Text);
            Clipboard.SetText("http://URL/shareWorld.php?id=" + worldIDs[index]);
        }
        static string[] args2;
        private Form1 form1 = new Form1(args2);
        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            int index = worldNames.IndexOf(worldsUD.Text);
            DialogResult result1 = MessageBox.Show("This action is irreversible. Are you sure you would like to permanently delete the world " + worldNames[index] + " from your computer and the MineSync server?","WARNING!", MessageBoxButtons.YesNo);
            WebClient wc = new WebClient();
            string username = Properties.Settings.Default.username;
            switch (result1)
            {
                case DialogResult.Yes:
                    this.mainForm.UploadRunning = true;
                    string uri = "http://URL/manageWorlds.php";
                    string wID = worldIDs[index];
                    string hash = CalculateMD5Hash("manageWorlds" + username + "RANDOMSTRING" + wID + "delete");
                    string param = "?type=2" + "&username=" + username + "&hash=" + hash + "&id=" + worldIDs[index] + "&wName=" + worldNames[index];
                    string url = uri + param;
                    byte[] response = wc.DownloadData(url);
                    string results = Encoding.ASCII.GetString(response);
                    string savePath;
                    if (Properties.Settings.Default.savesPath != "")
                    {
                        savePath = Properties.Settings.Default.savesPath;
                    }
                    else
                    {
                        savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\.minecraft\saves";
                    }
                    string deletePath = savePath + @"\" + worldNames[index];
                    Directory.Delete(deletePath, true);

                    WorldManager worldManager = new WorldManager(mainForm);
                    worldManager.Show();
                    this.Close();
                    form1.UploadRunning = false;
                    break;
                case DialogResult.No:
                    
                    break;
                    
            }
            
        }

        private void downloadCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingWorlds)
            {
                WebClient wc = new WebClient();
                string username = Properties.Settings.Default.username;

                //MessageBox.Show(hash);
                string uri = "http://URL/manageWorlds.php";
                int index = worldNames.IndexOf(worldsUD.Text);
                string wID = worldIDs[index];
                string hash;
                string results;
                if (downloadCheck.Checked)
                {
                    hash = CalculateMD5Hash("manageWorlds" + username + "RANDOMSTRING" + wID + "enabled");
                    string param = "?type=1" + "&username=" + username + "&hash=" + hash + "&id=" + worldIDs[index] + "&downloadable=enabled";
                    string url = uri + param;
                    byte[] response = wc.DownloadData(url);
                    results = Encoding.ASCII.GetString(response);
                    dlButton.Enabled = true;
                }
                else
                {
                    hash = CalculateMD5Hash("manageWorlds" + username + "RANDOMSTRING" + wID + "disabled");
                    string param = "?type=1" + "&username=" + username + "&hash=" + hash + "&id=" + worldIDs[index] + "&downloadable=disabled";
                    string url = uri + param;
                    byte[] response = wc.DownloadData(url);
                    results = Encoding.ASCII.GetString(response);
                    dlButton.Enabled = false;
                }
                if (results == "A fatal error occured")
                    MessageBox.Show("A fatal error occured");
            }
        }
    }
}
