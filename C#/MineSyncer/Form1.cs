using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Ionic.Zip;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Xml;
using Microsoft.Win32;

namespace MineSyncer
{
    public partial class Form1 : Form
    {
        string savePath = "";

        public Form1(string[] args)
        {
            if (args != null)
            {
                if (args.Length == 2)
                    if (args[1] == "delete")
                    {
                        System.IO.File.Delete(args[0]);
                        MessageBox.Show("MineSync has been updated successfully!", "Update Successful");
                    }
            }

            checkForUpdate();
            InitializeComponent();
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Properties.Settings.Default.chkStartUp)
            {
                rk.SetValue("MineSync", Application.ExecutablePath.ToString());
                Properties.Settings.Default.chkStartUp = true;
            }
            uLogBox.Text = Properties.Settings.Default.username;
            pLogBox.Text = Properties.Settings.Default.password;
            if (Properties.Settings.Default.savesPath != "")
            {
                savePath = Properties.Settings.Default.savesPath;
            }
            else
            {
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\.minecraft\saves";
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            login(); 
            
        }

        private void login()
        {
            string username = uLogBox.Text;
            string password = CalculateMD5Hash(pLogBox.Text + "RANDOMSTRING");
            WebClient wc = new WebClient();
            string uri = "http://xantecgames.com/MineSync/login.php";
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string vers2 = version.Replace(".", "");
            string param = "?username=" + username + "&password=" + password + "&version=" + vers2;
            string url = uri + param;
            byte[] response = wc.DownloadData(url);
            string results = Encoding.ASCII.GetString(response);

            string preHash = username + "RANDOMSTRING" + password;
            string hashCheck = CalculateMD5Hash(preHash);
            if (string.Equals(hashCheck, results, StringComparison.OrdinalIgnoreCase))
            {
                notifyIcon.Visible = true;
                loggedIn();
            }
            else
            {
                MessageBox.Show(results);
            }
        }

        string captchaName;
        private void registerButton_Click(object sender, EventArgs e)
        {
            foreach (string fileName in Directory.GetFiles(Application.UserAppDataPath))
            {
                if (fileName.Contains("captcha") && fileName != captchaName)
                {
                    //MessageBox.Show(fileName + ":" + captchaName);
                    File.Delete(Path.Combine(Application.UserAppDataPath, fileName));
                }
            }
            if (capString == captchaBox.Text)
            {
                string username = userBox.Text;
                string password = passBox.Text;
                string cpassword = cPassBox.Text;
                string email = mailBox.Text;
                if (password == cpassword && password != "")
                {
                    WebClient wc = new WebClient();
                    string uri = "http://URL/register.php";
                    string param = "?username=" + username + "&password=" + password + "&email=" + email;
                    string url = uri + param;
                    byte[] response = wc.DownloadData(url);
                    string results = Encoding.ASCII.GetString(response);
                    MessageBox.Show(results);
                }
                else
                {
                    MessageBox.Show("Your passwords do not match. ");
                }
            }
            else
            {
                MessageBox.Show("The captcha you entered does not match the image provided.");
            }
        }
        static bool LoggedIn = false;
        FileSystemWatcher watch = new FileSystemWatcher();
        Timer timer = new Timer();
        private void loggedIn()
        {
            //Minimize to taskbar
           // this.WindowState = FormWindowState.Minimized;
            LoggedIn = true;
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Show();
            loadingForm.Update();
            //System.Threading.Thread.Sleep(2500);
            
                Properties.Settings.Default.username = uLogBox.Text;
                Properties.Settings.Default.password = pLogBox.Text;
                Properties.Settings.Default.Save();
            loadingForm.Close();
            //this.WindowState = FormWindowState.Minimized;
            this.Hide();
            WebClient wc = new WebClient();
            string uri = "http://URL/makeStatus.php";
            string param = "?status=ON&user=" + Properties.Settings.Default.username;
            string url = uri + param;
            byte[] dlData = wc.DownloadData(url);
            string results = Encoding.ASCII.GetString(dlData);
            //MessageBox.Show(results);
            uLogBox.Enabled = false;
            pLogBox.Enabled = false;
            loginButton.Enabled = false;
            loginButton.Text = "Logged In";
            noAccount.Enabled = false;
            //download worlds
            foreach (string directory in Directory.GetDirectories(savePath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                string dirName = dirInfo.Name;
                if (dirName.Contains(","))
                {
                    dirName = dirName.Replace(",", "");
                    Directory.Move(directory, savePath + @"\" + dirName);
                    string worldName = dirInfo.Name;
                }
            }   
            checkForNewWorlds(false);
            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = 180000;          // Timer will tick evert second
            timer.Enabled = true;                       // Enable the timer
            timer.Start();                              // Start the timer
            //sync changes
            //watch.Path = Application.UserAppDataPath + @"\.minecraft\saves";
            watch.Path = savePath;
            watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watch.Changed += new FileSystemEventHandler(OnChanged);
            watch.Created += new FileSystemEventHandler(OnChanged);
            //watch.Deleted += new FileSystemEventHandler(OnChanged);
            watch.Renamed += new RenamedEventHandler(OnRenamed);

            watch.EnableRaisingEvents = true;
           
        }
        void timer_Tick(object sender, EventArgs e)
        {
            checkForNewWorlds(false);
            if (Properties.Settings.Default.intervalCheck)
            {
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.BalloonTipText = "Interval world check has started. \nYou can disable this notification in the settings menu.";
                notifyIcon.ShowBalloonTip(1);
            }
        }
        private bool uploadRunning;
        public bool UploadRunning
        {
            get
            {
                return uploadRunning;
            }
            set
            {
                uploadRunning = value;
            }
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            if (!uploadRunning)
            {
                uploadRunning = true;
                watch.Changed -= new FileSystemEventHandler(OnChanged);
                watch.Created -= new FileSystemEventHandler(OnChanged);
                //watch.Deleted -= new FileSystemEventHandler(OnChanged);
                watch.Renamed -= new RenamedEventHandler(OnRenamed);
                watch.EnableRaisingEvents = false;
                // Specify what is done when a file is changed, created, or deleted.
                //if (e.FullPath == @"D:\tmp\p.txt")
                //MessageBox.Show("File: " + e.FullPath + " " + e.ChangeType);
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.BalloonTipText = "Your world ''" + e.Name + "'' is syncing to the MineSync server...";
                notifyIcon.ShowBalloonTip(2);

                ///////////////////
                //ZIP World
                ///////////////////
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = CalculateMD5Hash(e.Name + Properties.Settings.Default.username + "RANDOMSTRING");
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    zip.AddDirectory(e.FullPath);
                    //zip.Comment = System.DateTime.Now.ToString("G");
                    DirectoryInfo di = new DirectoryInfo(e.FullPath);
                    DirectoryInfo parentDir = di.Parent;
                    string path = Application.UserAppDataPath + @"\" + e.Name + ".zip";
                    zip.Save(path);
                    System.Net.WebClient Client = new WebClient();
                    Client.Headers.Add("Content-Type", "application/octet-stream");
                    string zipHash = GetMD5HashFromFile(path);
                    string fileHash = CalculateMD5Hash(zipHash + uLogBox.Text.ToUpper() + "RANDOMSTRING");
                    string uploadUrl = "http://URL/upload.php?user=" + Properties.Settings.Default.username + "&hash=" + fileHash + "&fileName=" + e.Name + "&date=" + DateTime.Now;
                    byte[] result = Client.UploadFile(uploadUrl, "PUT", path);
                    string response = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                    File.Delete(path);
                    if (response != "Done")
                    {
                        MessageBox.Show("Error : " + response);
                    }

                }
                watch.Path = savePath;
                //watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                watch.Changed += new FileSystemEventHandler(OnChanged);
                watch.Created += new FileSystemEventHandler(OnChanged);
                //watch.Deleted += new FileSystemEventHandler(OnChanged);
                watch.Renamed += new RenamedEventHandler(OnRenamed);
                watch.EnableRaisingEvents = true;
                uploadRunning = false;
            }
            else
            {
                return;
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            
        }

        private static string GetMD5HashFromFile(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("X2"));
            }
            return sb.ToString();
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
        string capString = "";
        private void noAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            prepareRegister(); 
        }

        private void checkForNewWorlds(bool manualUpd)
        {
            if(!uploadRunning)
            {
                uploadRunning = true;
                watch.Changed -= new FileSystemEventHandler(OnChanged);
                watch.Created -= new FileSystemEventHandler(OnChanged);
                //watch.Deleted -= new FileSystemEventHandler(OnChanged);
                watch.Renamed -= new RenamedEventHandler(OnRenamed);
                watch.EnableRaisingEvents = false;
                string dir = savePath;
                string worldPath;
                WebClient wc = new WebClient();
                string[] allWorlds = Directory.GetDirectories(dir);
                string[] allWorldsNames = new string[allWorlds.Length];
                int i = 0;

                foreach(string allWorld in allWorlds)
                {
                    DirectoryInfo wdPath = new DirectoryInfo(allWorld);
                    allWorldsNames[i] = wdPath.Name;
                    i++;
                }
                //First check if the server has worlds that we dont
                string worldsLocal = string.Join(",", allWorldsNames);
                if (allWorlds.Length == 0)
                {
                    worldsLocal = "000";
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.BalloonTipText = "You currently have no worlds on your computer. If you have worlds on the MineSync server then they will be downloaded now. ";
                    notifyIcon.ShowBalloonTip(2);
                }
                string uri = "http://URL/worldChecker.php";
                string param = "?username=" + Properties.Settings.Default.username + "&worldList=" + worldsLocal;
                string url = uri + param;
                byte[] dlData = wc.DownloadData(url);
                string dlResults = Encoding.ASCII.GetString(dlData);
                //MessageBox.Show("Local Worlds : \n" + worldsLocal + "\nServer Unexist : \n" + dlResults);
                #region Local Database is up to date
                if (dlResults != "localDB-UTD")
                {
                    if (dlResults.Contains(","))
                    {
                        string[] neededWorlds = dlResults.Split(',');
                        foreach (string neededWorld in neededWorlds)
                        {
                            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                            notifyIcon.BalloonTipText = "Multiple worlds are being downloaded from the MineSync server...";
                            notifyIcon.ShowBalloonTip(2);
                            uri = "http://URL/downloadWorld.php";
                            param = "?worldName=" + neededWorld + "&username=" + Properties.Settings.Default.username + "&dl=1";
                            url = uri + param;
                            string fullZipPath = Application.UserAppDataPath + @"\" + neededWorld + ".zip";
                            string worldPath2 = savePath + @"\" + neededWorld;
                            if (File.Exists(fullZipPath))
                            {
                                File.Delete(fullZipPath);
                            }
                            wc.DownloadFile(url, fullZipPath);
                            byte[] fileBytes = File.ReadAllBytes(fullZipPath);
                            string response2 = System.Text.Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
                            //extract downloaded zip

                            if (Directory.Exists(worldPath2))
                            {
                                Directory.Delete(worldPath2, true);
                            }
                            using (ZipFile zip1 = ZipFile.Read(fullZipPath))
                            {
                                zip1.Password = CalculateMD5Hash(neededWorld + Properties.Settings.Default.username + "RANDOMSTRING");
                                zip1.Encryption = EncryptionAlgorithm.WinZipAes256;
                                // here, we extract every entry, but we could extract conditionally
                                // based on entry name, size, date, checkbox status, etc.  
                                foreach (ZipEntry e in zip1)
                                {
                                    e.Extract(worldPath2, ExtractExistingFileAction.OverwriteSilently);
                                }
                            }
                            File.Delete(fullZipPath);
                        }
                    }
                    else
                    {
                        notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon.BalloonTipText = "Your world ''" + dlResults + "'' is being downloaded from the MineSync server...";
                        notifyIcon.ShowBalloonTip(2);
                        uri = "http://URL/downloadWorld.php";
                        param = "?worldName=" + dlResults + "&username=" + Properties.Settings.Default.username + "&dl=1";
                        url = uri + param;
                        string fullZipPath = Application.UserAppDataPath + @"\" + dlResults + ".zip";
                        string worldPath2 = savePath + @"\" + dlResults;
                        if (File.Exists(fullZipPath))
                        {
                            File.Delete(fullZipPath);
                        }
                        wc.DownloadFile(url, fullZipPath);
                        byte[] fileBytes = File.ReadAllBytes(fullZipPath);
                        string response2 = System.Text.Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
                        //extract downloaded zip
                        if(response2 == "An unknown error has occured on the server")
                        {
                            MessageBox.Show("An error occured");
                            return;
                        }
                        string unpackDirectory = worldPath2;

                        if (Directory.Exists(worldPath2))
                        {
                            Directory.Delete(worldPath2, true);
                        }
                        using (ZipFile zip1 = ZipFile.Read(fullZipPath))
                        {
                            zip1.Password = CalculateMD5Hash(dlResults + Properties.Settings.Default.username + "RANDOMSTRING");
                            zip1.Encryption = EncryptionAlgorithm.WinZipAes256;
                            // here, we extract every entry, but we could extract conditionally
                            // based on entry name, size, date, checkbox status, etc.  
                            foreach (ZipEntry e in zip1)
                            {
                                e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                        File.Delete(fullZipPath);
                    }
                }
                #endregion
                //then check to see if the servers worlds are newer/ours are newer. 

                //Run this for every single world on computer
                #region ForEach world
                foreach (string directory in Directory.GetDirectories(dir))
                {   
                    DirectoryInfo dirInfo = new DirectoryInfo(directory);
                    string worldName = dirInfo.Name;
                    DateTime writeTime = dirInfo.LastWriteTimeUtc;
                    //MessageBox.Show(writeTime.ToString());
                    worldPath = dirInfo.FullName;
                    string fullZipPath = zipPathToParent(worldPath);
                    string zipCompare = GetMD5HashFromFile(fullZipPath);
                    string fileHash = CalculateMD5Hash(zipCompare + uLogBox.Text.ToUpper() + "RANDOMSTRING");
                        
                    File.Delete(fullZipPath);
                        
                    uri = "http://URL/downloadWorld.php";
                    param = "?worldName=" + worldName + "&dateTime=" + writeTime + "&username=" + Properties.Settings.Default.username + "&hash=" + fileHash;
                    url = uri + param;
                    byte[] response = wc.DownloadData(url);
                    string results = Encoding.ASCII.GetString(response);
                    //if(response == "Up to date")
                    #region Upload Result
                    if (results == "Upload")
                    {
                        ///////////////////
                        //ZIP World
                        ///////////////////
                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddDirectory(worldPath);
                            //zip.Comment = System.DateTime.Now.ToString("G");
                            DirectoryInfo di = new DirectoryInfo(worldPath);
                            DirectoryInfo parentDir = di.Parent;
                            zip.Password = CalculateMD5Hash(worldName + Properties.Settings.Default.username + "RANDOMSTRING");
                            zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                            zip.Save(Application.UserAppDataPath + @"\" + worldName + ".zip");

                            string path = Application.UserAppDataPath + @"\" + worldName + ".zip";
                            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                            notifyIcon.BalloonTipText = "Your world ''" + worldName + "'' is being synced to the MineSync server...";
                            notifyIcon.ShowBalloonTip(2);
                            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                            string zipHash = GetMD5HashFromFile(path);
                            string fileHash2 = CalculateMD5Hash(zipHash + uLogBox.Text.ToUpper() + "RANDOMSTRING");
                            string uploadUrl = "http://URL/upload.php?user=" + Properties.Settings.Default.username + "&hash=" + fileHash2 + "&fileName=" + worldName + "&date=" + DateTime.Now;
                            byte[] result = wc.UploadFile(uploadUrl, "PUT", path);
                            string response2 = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                            File.Delete(path);
                            if (response2 != "Done")
                            {
                                MessageBox.Show("Error : " + response2);
                            }
                        }
                    }
                    #endregion
                    #region Result not up to date
                    else if (results != "Up to date")
                    {
                        notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon.BalloonTipText = "Your world ''" + worldName + "'' is being downloaded from the MineSync server...";
                        notifyIcon.ShowBalloonTip(2);
                        param = "?worldName=" + worldName + "&dateTime=" + writeTime + "&username=" + Properties.Settings.Default.username + "&dl=1" + "&hash=" + fileHash;
                        url = uri + param;
                        if (File.Exists(fullZipPath))
                        {
                            File.Delete(fullZipPath);
                        }
                        wc.DownloadFile(url, fullZipPath);
                        byte[] fileBytes = File.ReadAllBytes(fullZipPath);
                        string response2 = System.Text.Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
                        //extract downloaded zip
                        string unpackDirectory = worldPath;

                        if (Directory.Exists(worldPath))
                        {
                            Directory.Delete(worldPath, true);
                        }
                        using (ZipFile zip1 = ZipFile.Read(fullZipPath))
                        {
                            zip1.Password = CalculateMD5Hash(worldName + Properties.Settings.Default.username + "RANDOMSTRING");
                            zip1.Encryption = EncryptionAlgorithm.WinZipAes256;
                            // here, we extract every entry, but we could extract conditionally
                            // based on entry name, size, date, checkbox status, etc.  
                            foreach (ZipEntry e in zip1)
                            {
                                e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                        File.Delete(fullZipPath);
                    }
                    #endregion
                    else
                    {
                        if (manualUpd)
                        {
                            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                            notifyIcon.BalloonTipText = "Your world ''" + worldName + "'' is currently up to date.";
                            notifyIcon.ShowBalloonTip(2);
                        }
                    }
                        
                    if (File.Exists(fullZipPath))
                    {
                        File.Delete(fullZipPath);
                    }
                }
                #endregion
                watch.Path = savePath;
                //watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                watch.Changed += new FileSystemEventHandler(OnChanged);
                watch.Created += new FileSystemEventHandler(OnChanged);
                //watch.Deleted += new FileSystemEventHandler(OnChanged);
                watch.Renamed += new RenamedEventHandler(OnRenamed);
                watch.EnableRaisingEvents = true;
                uploadRunning = false;
            }
            else
            {
                if (manualUpd)
                {
                    ///System.Threading.Thread.Sleep(2000);
                    //checkForNewWorlds();
                    MessageBox.Show("An upload is currently in process. Try again in a few seconds.");
                }
            }
        }

        private string zipPathToParent(string zipPath)
        {
            using (ZipFile zip = new ZipFile())
            {
                //var dir = Directory.GetParent(zipPath);
                DirectoryInfo dirInfo = new DirectoryInfo(zipPath);
                string worldName = dirInfo.Name;
                zip.Password = CalculateMD5Hash(worldName + Properties.Settings.Default.username + "RANDOMSTRING");
                zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                zip.AddDirectory(zipPath);
                //zip.Comment = System.DateTime.Now.ToString("G");
                DirectoryInfo parentDir = dirInfo.Parent;
                zip.Save(Application.UserAppDataPath + @"\" + worldName + ".zip");
                string path = Application.UserAppDataPath + @"\" + worldName + ".zip";
                return path;
            }
        }

        private void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            // Activate the form. 
            //this.Activate();
        }

        private void checkForUpdate()
        {
            try
            {
                WebClient wc = new WebClient();

                //Download the data of your XML file.
                string XMLContent = wc.DownloadString("http://URL/update.xml");

                //Create our XmlDocument
                //We will use this to read our XmlNodex.
                System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();

                //Load the data into our XmlDocument.
                Doc.LoadXml(XMLContent);

                //Select the node called 'verison' that is a sub-node of 'latest', and get the text.
                Version newVersion = new Version(Doc.SelectSingleNode("latest/version").InnerText);
                Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                if (applicationVersion.CompareTo(newVersion) < 0)
                {
                    updaterForm updF = new updaterForm();
                    updF.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to check for updates. \n" + ex.ToString());
            }
        }

        private void manualUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkForNewWorlds(true);
        }

        private void worldManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoggedIn)
            {
                //string[] args;
                WorldManager worldManager = new WorldManager(this);
                worldManager.Show();
            }
            else
            {
                MessageBox.Show("You must be logged in to your MineSync account before accessing this feature. ");
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm settingForm = new settingsForm();
            settingForm.Show();
            //settingForm.Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "";
            string business = "DONATE EMAIL";  // your paypal email
            string description = "Donation%20for%20MineSync";            // '%20' represents a space. remember HTML!
            string country = "US";                  // AU, US, etc.
            string currency = "USD";                 // AUD, USD, etc.

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            System.Diagnostics.Process.Start(url);
        }

        string RandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

            // Guid.NewGuid and System.Random are not particularly random. By using a
            // cryptographically-secure random number generator, the caller is always
            // protected, regardless of use.
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        // Divide the byte into allowedCharSet-sized groups. If the
                        // random value falls into the last group and the last group is
                        // too small to choose from the entire allowedCharSet, ignore
                        // the value in order to avoid biasing the result.
                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString();
            }
        }

        private void newCaptcha_Click(object sender, EventArgs e)
        {
            prepareRegister();
        }
        private void prepareRegister()
        {
            captchaPic.Image = null;
            this.Height = 502;
            capString = RandomString(10);
            // Kreiramo bmp file (sliku koja ce se kasnije prikazati u pictureBox1 kontroli).
            Bitmap bmp = new Bitmap(256, 60);
            Graphics gImage = Graphics.FromImage(bmp);
            gImage.FillRectangle(Brushes.BlanchedAlmond, 0, 0, bmp.Width, bmp.Height);
            // Odredjujemo font, boju teksta i deklarisemo DrawString metodu.
            Font CAPTCHAfont = new Font("Chiller", 24);
            Brush cetka = Brushes.Black;
            gImage.DrawString(capString, CAPTCHAfont, cetka, 0, 10);
            // Dodajemo linije preko teksta, da je (SPAM)programima teze procitati tekst.
            Pen p = new Pen(Color.Gray, 2);
            Random random = new Random();
            gImage.DrawLine(p, 230, random.Next(10, 40), 10, random.Next(10, 40));
            gImage.DrawLine(p, 230, random.Next(10, 40), 10, random.Next(10, 40));
            gImage.DrawLine(p, 230, random.Next(10, 40), 10, random.Next(10, 40));
            // Dodjeljujemo ime bmp fajlu.
            // Sacuvavamo bmp file.
            string rando = RandomString(16);
            bmp.Save(Application.UserAppDataPath + @"\captcha" + capString + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            //Prikazujemo bmp file u pictureBox kontroli.
            captchaPic.Image = new Bitmap(Application.UserAppDataPath + @"\captcha" + capString + ".bmp");
            captchaName = Application.UserAppDataPath + @"\captcha" + capString + ".bmp";
        }

        private void reportBug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BugForm bugForm = new BugForm();
            bugForm.Show();
        }

        private void bugSuggestionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugForm bugForm = new BugForm();
            bugForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
