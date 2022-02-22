using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;   // For DLL importing
using System.Threading;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SkulyRepack
{

    public partial class Form1 : Form
    {

        private const int SW_SHOW = 5;
        private const int SW_RESTORE = 9;
        private const int SW_MINIMIZE = 6;


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);
        public Form1()
        {
            InitializeComponent();

            FileInfo fInfo = new FileInfo(@"updater\launcher\Version.txt");

            if (fInfo.Exists)
            {
                string line1 = File.ReadLines(@"updater\launcher\Version.txt").First();
                this.Text = "SkulyRepack Update_" + line1;
            }
            else
            {

                this.Text = "SkulyRepack";
                String createText = "0";
                Directory.CreateDirectory(@"updater\launcher\");
                File.WriteAllText(@"updater\launcher\Version.txt", createText, Encoding.UTF8);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String mysqldcheck1 = "mysqld";
            Process[] mysqldcheck2 = Process.GetProcessesByName(mysqldcheck1);
            if ((mysqldcheck2.Length == 0))
            {
                FileInfo mInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

                if (mInfo.Exists)
                {
                    Process mysql = new Process();
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

        private void button2_Click(object sender, EventArgs e)
        {
            String authcheck1 = "authserver";
            Process[] authcheck2 = Process.GetProcessesByName(authcheck1);
            if ((authcheck2.Length == 0))
            {
                FileInfo authInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

                if (authInfo.Exists)
                {
                    Process Auth = new Process();
                    Auth.StartInfo.FileName = @"authserver.exe";
                    Auth.Start();
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

        private void button3_Click(object sender, EventArgs e)
        {

            String worldcheck1 = "worldserver";
            Process[] worldcheck2 = Process.GetProcessesByName(worldcheck1);
            if ((worldcheck2.Length == 0))
            {
                FileInfo wInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

                if (wInfo.Exists)
                {
                    Process World = new Process();
                    World.StartInfo.FileName = @"worldserver.exe";
                    World.Start();
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

        private void button4_Click(object sender, EventArgs e)
        {
            FileInfo aInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

            if (aInfo.Exists)
            {
                String sqlcheck1 = "mysqld";
                Process[] sqlcheck2 = Process.GetProcessesByName(sqlcheck1);
                if ((sqlcheck2.Length == 0))
                {
                    Process mysql = new Process();
                    mysql.StartInfo.FileName = @"MySQL\bin\mysqld.exe";
                    mysql.StartInfo.Arguments = "--console";
                    mysql.Start();
                    Thread.Sleep(4000);
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Mysql is already running!.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {

                    }

                }


                String authcheck1 = "authserver";
                Process[] authcheck2 = Process.GetProcessesByName(authcheck1);
                if ((authcheck2.Length == 0))
                {
                    Process Auth = new Process();
                    Auth.StartInfo.FileName = @"authserver.exe";
                    Auth.Start();
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



                String worldcheck1 = "worldserver";
                Process[] worldcheck2 = Process.GetProcessesByName(worldcheck1);
                if ((worldcheck2.Length == 0))
                {

                    Process World = new Process();
                    World.StartInfo.FileName = @"worldserver.exe";
                    World.Start();
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

        private void button13_Click(object sender, EventArgs e)
        {
            String ProcWindow = "authserver";
            Process[] procs = Process.GetProcessesByName(ProcWindow);
            foreach (Process proc in procs)
            {
                //switch to process by name
                ShowWindow(proc.MainWindowHandle, SW_MINIMIZE);

            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            String Procmysql = "mysqld";
            String Procauth = "authserver";
            String Procworld = "worldserver";


            Process[] procmysq = Process.GetProcessesByName(Procmysql);
            Process[] procauth = Process.GetProcessesByName(Procauth);
            Process[] procworld = Process.GetProcessesByName(Procworld);


            if (this.button14.Text == "Restore Servers")
            {

                foreach (Process proc in procmysq)
                {
                    ShowWindow(proc.MainWindowHandle, SW_RESTORE);
                }

                foreach (Process proc in procauth)
                {
                    ShowWindow(proc.MainWindowHandle, SW_RESTORE);
                }

                foreach (Process proc in procworld)
                {
                    ShowWindow(proc.MainWindowHandle, SW_RESTORE);
                }

                this.button14.Text = "Minimize Servers";

            }
            else
            {

                foreach (Process proc in procmysq)
                {
                    ShowWindow(proc.MainWindowHandle, SW_MINIMIZE);
                }

                foreach (Process proc in procauth)
                {
                    ShowWindow(proc.MainWindowHandle, SW_MINIMIZE);
                }

                foreach (Process proc in procworld)
                {
                    ShowWindow(proc.MainWindowHandle, SW_MINIMIZE);
                }

                this.button14.Text = "Restore Servers";
            }
        }


        private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(hwnd, ref placement);
            return placement;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(
            IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public ShowWindowCommands showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        internal enum ShowWindowCommands : int
        {
            Hide = 0,
            Normal = 1,
            Minimized = 2,
            Maximized = 3,
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(); // Shows Form2
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog(); // Shows Form3
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog(); // Shows Form4
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/donate/?business=UXEPUCHFZGDHG&no_recurring=0&currency_code=USD");
        }

        private void button10_Click(object sender, EventArgs e)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://raw.githubusercontent.com/Juggalo187/Repack_updater/main/NetVersion.txt", @"updater\launcher\NetVersion.txt");




            FileInfo vfile = new FileInfo(@"updater\launcher\Version.txt");
            FileInfo rfile = new FileInfo(@"updater\launcher\NetVersion.txt");
            if (vfile.Exists && rfile.Exists)
            {
                string vline1 = File.ReadLines(@"updater\launcher\Version.txt").First();
                string line1 = File.ReadLines(@"updater\launcher\NetVersion.txt").First();
                if (Convert.ToInt32(line1) > Convert.ToInt32(vline1))
                {
                    DialogResult d;
                    d = MessageBox.Show("You have version " + vline1 + " and version " + line1 + " is available for download. Would you like to download page?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://mega.nz/folder/WogBxYgA#bdu86gjeyDUKsyS95KEJfA");
                    }



                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("There doesn't seem to be an update avaiable. would you like to open the download page and check for a new update anyway?", "check for update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (d == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://mega.nz/folder/WogBxYgA#bdu86gjeyDUKsyS95KEJfA");
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/VtrVvVjCPH");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var fileContent = string.Empty;
            var filePath = string.Empty;

            FileInfo fInfo = new FileInfo(@"updater\launcher\wowstart.txt");

            if (fInfo.Exists)
            {
                string line1 = File.ReadLines(@"updater\launcher\wowstart.txt").First();
                FileInfo fInfo2 = new FileInfo(line1);
                if (fInfo2.Exists)
                {

                    Process Wow = new Process();
                    Wow.StartInfo.FileName = line1;
                    Wow.Start();
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
                        string path = @"updater\launcher\";
                        DirectoryInfo di = Directory.CreateDirectory(path);

                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        Process Wow = new Process();
                        Wow.StartInfo.FileName = filePath;
                        Wow.Start();

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
                    string path = @"updater\launcher\";
                    DirectoryInfo di = Directory.CreateDirectory(path);

                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    Process Wow = new Process();
                    Wow.StartInfo.FileName = filePath;
                    Wow.Start();

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

        private void button9_Click(object sender, EventArgs e)
        {

            Form5 f5 = new Form5();
            f5.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            String Procworld = "worldserver";
            Process[] procworld = Process.GetProcessesByName(Procworld);

            if ((procworld.Length != 0))
            {
                foreach (Process proc in procworld)
                {
                    SetForegroundWindow(proc.MainWindowHandle);
                    SendKeys.Send("server shutdown force 1");
                    SendKeys.Send("{ENTER}");
                    Thread.Sleep(3000);
                }
            }


            String Procauthkill = "authserver";
            Process[] Procauthkill2 = Process.GetProcessesByName(Procauthkill);

            if ((Procauthkill.Length != 0))
            {
                foreach (Process proc2 in Procauthkill2)
                {
                    proc2.Kill();
                }
            }


            Process mysqladmin = new Process();

            mysqladmin.StartInfo.FileName = @"MySQL\bin\mysqladmin.exe";
            mysqladmin.StartInfo.Arguments = "-u root --password=root shutdown";

            mysqladmin.StartInfo.UseShellExecute = true;
            mysqladmin.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            mysqladmin.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
