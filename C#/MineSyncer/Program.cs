using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MineSyncer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string uri = "http://URL/makeStatus.php";
            string param = "?status=OFF&user=" + Properties.Settings.Default.username;
            string url = uri + param;
            byte[] dlData = wc.DownloadData(url);
        }
    }
}
