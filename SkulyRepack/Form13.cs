using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
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
                    var isNumeric = int.TryParse(textBox1.Text, out _);
                    if (isNumeric)
                    {
                        var createText = "SET @RESPAWNTIME = " + textBox1.Text + ";";
                        Directory.CreateDirectory(@"updater\launcher\sql\NodeRespawn\backup");
                        File.WriteAllText(@"updater\launcher\sql\NodeRespawn\execute.sql", createText, Encoding.UTF8);


                        DialogResult b;
                        b = MessageBox.Show("Would you like to make a backup before saving?", "Node Respawn", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (b == DialogResult.Yes)
                        {
                            var mysqldump = new Process();
                            mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                            mysqldump.StartInfo.Arguments = "-u root --password=root world gameobject --result-file=" + @"updater\launcher\sql\NodeRespawn\backup\NodeDump.sql";
                            mysqldump.StartInfo.UseShellExecute = true;
                            mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            mysqldump.Start();
                            mysqldump.WaitForExit();


                            var fullPath = Path.GetFullPath(@"updater\launcher\sql\NodeRespawn\backup\NodeDump.sql");
                            var originalbackup = new FileInfo(@"updater\launcher\sql\NodeRespawn\backup\NodeDump_Original.sql");
                            if (!originalbackup.Exists)
                            { File.Copy(Path.Combine(@"updater\launcher\sql\NodeRespawn\backup", "NodeDump.sql"), Path.Combine(@"updater\launcher\sql\NodeRespawn\backup", "NodeDump_Original.sql")); }

                            DialogResult c;
                            c = MessageBox.Show("Backup was saved to " + fullPath, "Node Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (c == DialogResult.OK)
                            {

                            }

                        }

                        var text = System.IO.File.ReadAllText(@"updater\launcher\sql\NodeRespawn\execute2.sql");
                        var appendText = text;
                        File.AppendAllText(@"updater\launcher\sql\NodeRespawn\execute.sql", appendText);


                        var spawntime = new Process();
                        var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\NodeRespawn\execute.sql";
                        spawntime.StartInfo.FileName = "cmd.exe";
                        spawntime.StartInfo.Arguments = spawntimestring;
                        spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        spawntime.Start();
                        spawntime.WaitForExit();


                        DialogResult d;
                        d = MessageBox.Show("Most Mineral and Herb Nodes should now respawn " + textBox1.Text + " seconds after being emptied.", "Node Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                        {
                            Close();
                        }



                    }
                    else
                    {
                        DialogResult checkifnum;
                        checkifnum = MessageBox.Show("You must enter a Number", "Node Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (checkifnum == DialogResult.OK)
                        {

                        }


                    }
                }
                else
                {
                    var isNumeric = int.TryParse(textBox1.Text, out _);
                    if (isNumeric)
                    {

                        var createText = "SET @Spawntime = " + textBox1.Text + ";";
                        Directory.CreateDirectory(@"updater\launcher\sql\NodeRespawn\backup");
                        File.WriteAllText(@"updater\launcher\sql\NodeRespawn\execute.sql", createText, Encoding.UTF8);


                        DialogResult b;
                        b = MessageBox.Show("Would you like to make a backup before saving?", "Node Respawn", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (b == DialogResult.Yes)
                        {
                            var mysqldump = new Process();
                            mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                            mysqldump.StartInfo.Arguments = "-u root --password=root world gameobject --result-file=" + @"updater\launcher\sql\NodeRespawn\backup\NodeDump.sql";
                            mysqldump.StartInfo.UseShellExecute = true;
                            mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            mysqldump.Start();
                            mysqldump.WaitForExit();

                            var fullPath = Path.GetFullPath(@"updater\launcher\sql\NodeRespawn\backup\NodeDump.sql");
                            var originalbackup = new FileInfo(@"updater\launcher\sql\NodeRespawn\backup\NodeDump_Original.sql");
                            if (!originalbackup.Exists)
                            { File.Copy(Path.Combine(@"updater\launcher\sql\NodeRespawn\backup", "NodeDump.sql"), Path.Combine(@"updater\launcher\sql\NodeRespawn\backup", "NodeDump_Original.sql")); }

                            DialogResult c;
                            c = MessageBox.Show("Backup was saved to " + fullPath, "Node Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (c == DialogResult.OK)
                            {

                            }
                        }

                        var text = System.IO.File.ReadAllText(@"updater\launcher\sql\NodeRespawn\execute2.sql");
                        var appendText = text;
                        File.AppendAllText(@"updater\launcher\sql\NodeRespawn\execute.sql", appendText);

                        var spawntime = new Process();
                        var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\NodeRespawn\execute.sql";
                        spawntime.StartInfo.FileName = "cmd.exe";
                        spawntime.StartInfo.Arguments = spawntimestring;
                        spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        spawntime.Start();
                        spawntime.WaitForExit();


                        DialogResult d;
                        d = MessageBox.Show("Most Mining and Herb nodes should now respawn " + textBox1.Text + " seconds after being emptied.", "Node Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                        {
                            Close();
                        }



                    }
                    else
                    {
                        DialogResult checkifnum;
                        checkifnum = MessageBox.Show("You must enter a Number", "Node Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (checkifnum == DialogResult.OK)
                        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            var restorefile = new FileInfo(@"updater\launcher\sql\NodeRespawn\backup\NodeDump_Original.sql");

            if (restorefile.Exists)
            {
                var spawntime = new Process();
                var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\NodeRespawn\backup\NodeDump_Original.sql";
                spawntime.StartInfo.FileName = "cmd.exe";
                spawntime.StartInfo.Arguments = spawntimestring;
                spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                spawntime.Start();
                spawntime.WaitForExit();


                DialogResult d;
                d = MessageBox.Show("Original gameobject table restored.", "Node Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {
                    Close();
                }
            }
            else
            {

                DialogResult d;
                d = MessageBox.Show("You don't have a backup to restore", "Node Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {
                    Close();
                }

            }
        }
    }
}
