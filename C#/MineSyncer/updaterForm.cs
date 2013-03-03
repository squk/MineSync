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
using System.Net;

namespace MineSyncer
{
    public partial class updaterForm : Form
    {
        public updaterForm()
        {
            InitializeComponent();
            CheckForUpdates();
        }

        public void CheckForUpdates()
        {
            //Create our webclient for download our strings and file.
            WebClient wc = new WebClient();

            //Download the data of your XML file.
            string XMLContent = wc.DownloadString("http://URL/update.xml");

            //Create our XmlDocument
            //We will use this to read our XmlNodex.
            System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();

            //Load the data into our XmlDocument.
            Doc.LoadXml(XMLContent);

            //Select the node called 'verison' that is a sub-node of 'latest', and get the text.
            string appVersion = Doc.SelectSingleNode("latest/version").InnerText;
            //Select the node called 'download' that is a sub-node of 'latest', and get the text.
            string DownloadLink = Doc.SelectSingleNode("latest/download").InnerText;
            string changes = Doc.SelectSingleNode("latest/changes").InnerText;

            //When the progress has changed.
            //Updates the text to what percentage of the updated
            //file it has downloaded.
            string DownloadPath = Path.GetTempFileName() + ".exe";
            wc.DownloadProgressChanged += (s, ev) =>
            {
                Text = "Updating... " + ev.ProgressPercentage.ToString() + "% Complete";
            };

            //Called when the file is done downloading.
            wc.DownloadFileCompleted += (s, ev) =>
            {
                //The DeletePath will be where the current process will be stored.
                string DeletePath = Path.GetTempFileName() + ".exe";

                //We move the current application to the DeletePath path.
                //Remember: A file CAN be moved while running.
                //It CANNOT be deleted though.
                File.Move(Application.ExecutablePath, DeletePath);

                //We now move the most update file to the original location of our program.
                File.Move(DownloadPath, Application.ExecutablePath);

                //If some how the updated file is not there, we will
                //simply restore the original file.
                if (!File.Exists(Application.ExecutablePath))
                {
                    File.Delete(Application.ExecutablePath);
                    File.Move(DeletePath, Application.ExecutablePath);

                    MessageBox.Show("Update failed... Your file has been restored to its original location.", "Update Failed");
                    Close();
                }

                //Create a new process containing the information for our updated version.
                System.Diagnostics.Process Proccess = new System.Diagnostics.Process()
                {
                    //The second argument are the parameters.
                    //We pass the old location path to it, and also a
                    //'delete' key word, telling our application what to do with that path.
                    StartInfo = new System.Diagnostics.ProcessStartInfo(Application.ExecutablePath, DeletePath + " delete")
                };

                //We then start the process.
                Proccess.Start();

                //And kill the current.
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            };

            //See if the versions are equal or not.
            Version newVersion = new Version(appVersion);
            Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            
            if (applicationVersion.CompareTo(newVersion) < 0)
            {
                //If not, we start the download of the latest version.
                //We use DownloadLink as the download link, because that
                //is the link that we got off the XML file.
                wc.DownloadFileAsync(new Uri(DownloadLink), DownloadPath);
            }
            else
            {
                //No update is available.
                Close();
            }
        }
    }
}
