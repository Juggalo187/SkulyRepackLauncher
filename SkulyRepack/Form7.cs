using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                    mysql.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    mysql.Start();
                    Thread.Sleep(4000);

                    String createText = "SET @REALMIP = \"" + textBox1.Text + "\";";
            Directory.CreateDirectory(@"updater\launcher\sql\RealmIP");
            File.WriteAllText(@"updater\launcher\sql\RealmIP\RealmIP.sql", createText, Encoding.UTF8);

            String text = System.IO.File.ReadAllText(@"updater\launcher\sql\RealmIP\RealmIP2.sql");
            String appendText = text;
            File.AppendAllText(@"updater\launcher\sql\RealmIP\RealmIP.sql", appendText);


            Process spawntime = new Process();
            string spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root auth < " + @"updater\launcher\sql\RealmIP\RealmIP.sql";
            spawntime.StartInfo.FileName = "cmd.exe";
            spawntime.StartInfo.Arguments = spawntimestring;
            spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            spawntime.Start();
            spawntime.WaitForExit();

            DialogResult d;
            d = MessageBox.Show("Realmlist IP was changed to " + textBox1.Text + ".", "RealmIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (d == DialogResult.OK)
            {
                Close();
            }
            }
                else
                {

                    String createText = "SET @REALMIP = \"" + textBox1.Text + "\";";
                    Directory.CreateDirectory(@"updater\launcher\sql\RealmIP");
                    File.WriteAllText(@"updater\launcher\sql\RealmIP\RealmIP.sql", createText, Encoding.UTF8);

                    String text = System.IO.File.ReadAllText(@"updater\launcher\sql\RealmIP\RealmIP2.sql");
                    String appendText = text;
                    File.AppendAllText(@"updater\launcher\sql\RealmIP\RealmIP.sql", appendText);


                    Process spawntime = new Process();
                    string spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root auth < " + @"updater\launcher\sql\RealmIP\RealmIP.sql";
                    spawntime.StartInfo.FileName = "cmd.exe";
                    spawntime.StartInfo.Arguments = spawntimestring;
                    spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    spawntime.Start();
                    spawntime.WaitForExit();

                    DialogResult d;
                    d = MessageBox.Show("Realmlist IP was changed to " + textBox1.Text + ".", "RealmIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (d == DialogResult.OK)
                    {
                        Close();
                    }
                }

            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Make sure this program is in the repack folder.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {
                    Close();
                }

            }




        }
    }
}
