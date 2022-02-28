using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
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
                    mysql.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    mysql.Start();
                    Thread.Sleep(4000);

                    if (textBox1.Text.Length > 4)
                    {
                        var createText = "SET @REALMIP = \"" + textBox1.Text + "\";";
                        Directory.CreateDirectory(@"updater\launcher\sql\RealmIP");
                        File.WriteAllText(@"updater\launcher\sql\RealmIP\RealmIP.sql", createText, Encoding.UTF8);

                        var text = System.IO.File.ReadAllText(@"updater\launcher\sql\RealmIP\RealmIP2.sql");
                        var appendText = text;
                        File.AppendAllText(@"updater\launcher\sql\RealmIP\RealmIP.sql", appendText);

                        var spawntime = new Process();
                        var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root auth < " + @"updater\launcher\sql\RealmIP\RealmIP.sql";
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
                        DialogResult m;
                        m = MessageBox.Show("Are you sure you entered an IP or Domain name? You entered less than 4 characters/digits.", "RealmIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (m == DialogResult.OK)
                        {
                            Close();
                        }
                    }


                }
                else
                {

                    if (textBox1.Text.Length > 4)
                    {
                        var createText = "SET @REALMIP = \"" + textBox1.Text + "\";";
                        Directory.CreateDirectory(@"updater\launcher\sql\RealmIP");
                        File.WriteAllText(@"updater\launcher\sql\RealmIP\RealmIP.sql", createText, Encoding.UTF8);

                        var text = System.IO.File.ReadAllText(@"updater\launcher\sql\RealmIP\RealmIP2.sql");
                        var appendText = text;
                        File.AppendAllText(@"updater\launcher\sql\RealmIP\RealmIP.sql", appendText);

                        var spawntime = new Process();
                        var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root auth < " + @"updater\launcher\sql\RealmIP\RealmIP.sql";
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
                        DialogResult m;
                        m = MessageBox.Show("Are you sure you entered an IP or Domain name? You entered less than 4 characters/digits.", "RealmIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (m == DialogResult.OK)
                        {
                            Close();
                        }
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
