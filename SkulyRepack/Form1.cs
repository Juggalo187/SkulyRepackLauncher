using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;   // For DLL importing
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SkulyRepack
{

    public partial class Form1 : Form
    {

        private const int SW_RESTORE = 9;
        private const int SW_MINIMIZE = 6;


        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);
        public Form1()
        {
            InitializeComponent();
            var fInfo = new FileInfo(@"updater\launcher\Version.txt");

            if (fInfo.Exists)
            {
                var line1 = File.ReadLines(@"updater\launcher\Version.txt").First();
                Text = "SkulyRepack Update_" + line1;
            }
            else
            {

                Text = "SkulyRepack";
                var createText = "0";
                Directory.CreateDirectory(@"updater\launcher\");
                File.WriteAllText(@"updater\launcher\Version.txt", createText, Encoding.UTF8);
            }

            var vfile = new FileInfo(@"updater\launcher\Version.txt");
            var rfile = new FileInfo(@"updater\launcher\NetVersion.txt");

            if (rfile.Exists)
            {
                File.Delete(@"updater\launcher\NetVersion.txt");
            }

            var webClient = new WebClient();
            webClient.DownloadFile("https://raw.githubusercontent.com/Juggalo187/Repack_updater/main/NetVersion.txt", @"updater\launcher\NetVersion.txt");

            if (vfile.Exists && rfile.Exists)
            {
                var vline1 = File.ReadLines(@"updater\launcher\Version.txt").First();
                var line1 = File.ReadLines(@"updater\launcher\NetVersion.txt").First();
                if (Convert.ToInt32(line1) > Convert.ToInt32(vline1))
                {
                    DialogResult d;
                    d = MessageBox.Show("You have version " + vline1 + " and version " + line1 + " is available for download. Would you like to open the download page?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://mega.nz/folder/WogBxYgA#bdu86gjeyDUKsyS95KEJfA/folder/Op42FZLY");
                    }



                }
            }






        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var mysqldcheck1 = "mysqld";
            var mysqldcheck2 = Process.GetProcessesByName(mysqldcheck1);
            if ((mysqldcheck2.Length == 0))
            {
                var mInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

                if (mInfo.Exists)
                {
                    var mysql = new Process();
                    mysql.StartInfo.FileName = @"MySQL\bin\mysqld.exe";
                    mysql.StartInfo.Arguments = "--console";
                    mysql.Start();
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Make sure this program is in the repack folder.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {

                    }

                }
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Mysql is already running!.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {

                }

            }


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var authcheck1 = "authserver";
            var authcheck2 = Process.GetProcessesByName(authcheck1);
            if ((authcheck2.Length == 0))
            {
                var authInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

                if (authInfo.Exists)
                {
                    var auth = new Process();
                    auth.StartInfo.FileName = @"authserver.exe";
                    auth.Start();
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Make sure this program is in the repack folder.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {

                    }

                }

            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Authserver is already running!.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {

                }

            }



        }

        private void Button3_Click(object sender, EventArgs e)
        {

            var worldcheck1 = "worldserver";
            var worldcheck2 = Process.GetProcessesByName(worldcheck1);
            if ((worldcheck2.Length == 0))
            {
                var wInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

                if (wInfo.Exists)
                {
                    var world = new Process();
                    world.StartInfo.FileName = @"worldserver.exe";
                    world.Start();
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Make sure this program is in the repack folder.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {

                    }

                }
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Worldserver is already running!.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {

                }

            }





        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var aInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

            if (aInfo.Exists)
            {
                var sqlcheck1 = "mysqld";
                var sqlcheck2 = Process.GetProcessesByName(sqlcheck1);
                if ((sqlcheck2.Length == 0))
                {
                    var mysql = new Process();
                    mysql.StartInfo.FileName = @"MySQL\bin\mysqld.exe";
                    mysql.StartInfo.Arguments = "--console";
                    mysql.Start();
                    Thread.Sleep(10000);
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Mysql is already running!.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {

                    }

                }


                var authcheck1 = "authserver";
                var authcheck2 = Process.GetProcessesByName(authcheck1);
                if ((authcheck2.Length == 0))
                {
                    var auth = new Process();
                    auth.StartInfo.FileName = @"authserver.exe";
                    auth.Start();
                    Thread.Sleep(2000);
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Authserver is already running!.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {

                    }

                }



                var worldcheck1 = "worldserver";
                var worldcheck2 = Process.GetProcessesByName(worldcheck1);
                if ((worldcheck2.Length == 0))
                {

                    var world = new Process();
                    world.StartInfo.FileName = @"worldserver.exe";
                    world.Start();
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Worldserver is already running!.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {

                    }

                }
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Make sure this program is in the repack folder.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {

                }

            }

        }

        private void Button13_Click(object sender, EventArgs e)
        {
            var procWindow = "authserver";
            var procs = Process.GetProcessesByName(procWindow);
            foreach (var proc in procs)
            {
                //switch to process by name
                ShowWindow(proc.MainWindowHandle, SW_MINIMIZE);

            }

        }

        private void Button14_Click(object sender, EventArgs e)
        {
            var procmysqlstring = "mysqld";
            var procauthstring = "authserver";
            var procworldstring = "worldserver";


            var procmysq = Process.GetProcessesByName(procmysqlstring);
            var procauth = Process.GetProcessesByName(procauthstring);
            var procworld = Process.GetProcessesByName(procworldstring);


            if (button14.Text == "Restore Servers")
            {

                foreach (var proc in procmysq)
                {
                    ShowWindow(proc.MainWindowHandle, SW_RESTORE);
                }

                foreach (var proc in procauth)
                {
                    ShowWindow(proc.MainWindowHandle, SW_RESTORE);
                }

                foreach (var proc in procworld)
                {
                    ShowWindow(proc.MainWindowHandle, SW_RESTORE);
                }

                button14.Text = "Minimize Servers";

            }
            else
            {

                foreach (var proc in procmysq)
                {
                    ShowWindow(proc.MainWindowHandle, SW_MINIMIZE);
                }

                foreach (var proc in procauth)
                {
                    ShowWindow(proc.MainWindowHandle, SW_MINIMIZE);
                }

                foreach (var proc in procworld)
                {
                    ShowWindow(proc.MainWindowHandle, SW_MINIMIZE);
                }

                button14.Text = "Restore Servers";
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(
            IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public int _length;
            public int _flags;
            public ShowWindowCommands _showCmd;
            public System.Drawing.Point _ptMinPosition;
            public System.Drawing.Point _ptMaxPosition;
            public System.Drawing.Rectangle _rcNormalPosition;
        }

        internal enum ShowWindowCommands : int
        {
            Hide = 0,
            Normal = 1,
            Minimized = 2,
            Maximized = 3,
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.ShowDialog(); // Shows Form2
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var f3 = new Form3();
            f3.ShowDialog(); // Shows Form3
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var f4 = new Form4();
            f4.ShowDialog(); // Shows Form4
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/donate/?business=UXEPUCHFZGDHG&no_recurring=0&currency_code=USD");
        }

        private void Button10_Click(object sender, EventArgs e)
        {

            var webClient = new WebClient();
            webClient.DownloadFile("https://raw.githubusercontent.com/Juggalo187/Repack_updater/main/NetVersion.txt", @"updater\launcher\NetVersion.txt");




            var vfile = new FileInfo(@"updater\launcher\Version.txt");
            var rfile = new FileInfo(@"updater\launcher\NetVersion.txt");
            if (vfile.Exists && rfile.Exists)
            {
                var vline1 = File.ReadLines(@"updater\launcher\Version.txt").First();
                var line1 = File.ReadLines(@"updater\launcher\NetVersion.txt").First();
                if (Convert.ToInt32(line1) > Convert.ToInt32(vline1))
                {
                    DialogResult d;
                    d = MessageBox.Show("You have version " + vline1 + " and version " + line1 + " is available for download. Would you like to open the download page?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://mega.nz/folder/WogBxYgA#bdu86gjeyDUKsyS95KEJfA/folder/Op42FZLY");
                    }



                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("There doesn't seem to be an update avaiable. would you like to open the download page and check for a new update anyway?", "check for update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://mega.nz/folder/WogBxYgA#bdu86gjeyDUKsyS95KEJfA/folder/Op42FZLY");
                    }

                }

            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("There was a problem checking for update.", "check for update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {

                }

            }

        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/VtrVvVjCPH");
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var fInfo = new FileInfo(@"updater\launcher\wowstart.txt");

            string filePath;
            if (fInfo.Exists)
            {
                var line1 = File.ReadLines(@"updater\launcher\wowstart.txt").First();
                var fInfo2 = new FileInfo(line1);
                if (fInfo2.Exists)
                {

                    var wow = new Process();
                    wow.StartInfo.FileName = line1;
                    wow.Start();
                }
                else
                {
                    File.Delete(@"updater\launcher\wowstart.txt");
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "exe files (*.exe)|*.exe";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var path = @"updater\launcher\";
                        _ = Directory.CreateDirectory(path);

                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        var wow = new Process();
                        wow.StartInfo.FileName = filePath;
                        wow.Start();

                        TextWriter txt = new StreamWriter(@"updater\launcher\wowstart.txt");
                        txt.Write(filePath);
                        txt.Close();

                    }

                }
            }
            else
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "exe files (*.exe)|*.exe";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var path = @"updater\launcher\";
                    _ = Directory.CreateDirectory(path);

                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    var wow = new Process();
                    wow.StartInfo.FileName = filePath;
                    wow.Start();

                    TextWriter txt = new StreamWriter(@"updater\launcher\wowstart.txt");
                    txt.Write(filePath);
                    txt.Close();

                }



            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            Application.Exit(); // or this.Close();
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            Application.Exit(); // or this.Close();
        }

        private void Button9_Click(object sender, EventArgs e)
        {

            var f5 = new Form5();
            f5.ShowDialog();

        }

        private void Button8_Click(object sender, EventArgs e)
        {

            var procworldstring = "worldserver";
            var procworld = Process.GetProcessesByName(procworldstring);

            if ((procworld.Length != 0))
            {
                foreach (var proc in procworld)
                {
                    SetForegroundWindow(proc.MainWindowHandle);
                    SendKeys.Send("server shutdown force 1");
                    SendKeys.Send("{ENTER}");
                    Thread.Sleep(3000);
                }
            }


            var procauthkillstring = "authserver";
            var procauthkill2 = Process.GetProcessesByName(procauthkillstring);

            if ((procauthkill2.Length != 0))
            {
                foreach (var proc2 in procauthkill2)
                {
                    proc2.Kill();
                }
            }


            var mysqladmin = new Process();

            mysqladmin.StartInfo.FileName = @"MySQL\bin\mysqladmin.exe";
            mysqladmin.StartInfo.Arguments = "-u root --password=root shutdown";

            mysqladmin.StartInfo.UseShellExecute = true;
            mysqladmin.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            mysqladmin.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            var f10 = new Form10();
            f10.ShowDialog();
        }
    }

}
