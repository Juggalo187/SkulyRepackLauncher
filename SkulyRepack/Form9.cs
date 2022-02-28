using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var aInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

            if (aInfo.Exists)
            {
                var isNumeric = int.TryParse(textBox1.Text, out _);
                if (isNumeric)
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

                        var createText = "SET @NPCID = " + textBox1.Text + ";";
                        Directory.CreateDirectory(@"updater\launcher\sql\NPCDelete");
                        File.WriteAllText(@"updater\launcher\sql\NPCDelete\NPCDelete.sql", createText, Encoding.UTF8);

                        var text = System.IO.File.ReadAllText(@"updater\launcher\sql\NPCDelete\NPCDelete2.sql");
                        var appendText = text;
                        File.AppendAllText(@"updater\launcher\sql\NPCDelete\NPCDelete.sql", appendText);


                        DialogResult b;
                        b = MessageBox.Show("Would you like to make a backup before deleting spawns?", "NPCDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (b == DialogResult.Yes)
                        {
                            Directory.CreateDirectory(@"updater\launcher\sql\NPCDelete\backup");
                            var mysqldump = new Process();
                            mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                            mysqldump.StartInfo.Arguments = "-u root --password=root world creature --result-file=" + @"updater\launcher\sql\NPCDelete\backup\NPCDeleteDump.sql";
                            mysqldump.StartInfo.UseShellExecute = true;
                            mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            mysqldump.Start();
                            mysqldump.WaitForExit();


                            var fullPath = Path.GetFullPath(@"updater\launcher\sql\NPCDelete\backup\NPCDeleteDump.sql");
                            var originalbackup = new FileInfo(@"updater\launcher\sql\CreatureSpawntime\backup\NPCDeleteDump_Original.sql");
                            if (!originalbackup.Exists)
                            { File.Copy(Path.Combine(@"updater\launcher\sql\NPCDelete\backup", "NPCDeleteDump.sql"), Path.Combine(@"updater\launcher\sql\NPCDelete\backup", "NPCDeleteDump_Original.sql")); }

                            DialogResult c;
                            c = MessageBox.Show("Backup was saved to " + fullPath, "NPCDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (c == DialogResult.OK)
                            {

                            }

                        }



                        var spawntime = new Process();
                        var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\NPCDelete\NPCDelete.sql";
                        spawntime.StartInfo.FileName = "cmd.exe";
                        spawntime.StartInfo.Arguments = spawntimestring;
                        spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        spawntime.Start();
                        spawntime.WaitForExit();

                        DialogResult d;
                        d = MessageBox.Show("Npc entry " + textBox1.Text + " spawns were removed.", "NPCDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                        {
                            Close();
                        }
                    }
                    else
                    {

                        var createText = "SET @NPCID = " + textBox1.Text + ";";
                        Directory.CreateDirectory(@"updater\launcher\sql\NPCDelete");
                        File.WriteAllText(@"updater\launcher\sql\NPCDelete\NPCDelete.sql", createText, Encoding.UTF8);

                        var text = System.IO.File.ReadAllText(@"updater\launcher\sql\NPCDelete\NPCDelete2.sql");
                        var appendText = text;
                        File.AppendAllText(@"updater\launcher\sql\NPCDelete\NPCDelete.sql", appendText);

                        DialogResult b;
                        b = MessageBox.Show("Would you like to make a backup before deleting spawns?", "NPCDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (b == DialogResult.Yes)
                        {
                            Directory.CreateDirectory(@"updater\launcher\sql\NPCDelete\backup");
                            var mysqldump = new Process();
                            mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                            mysqldump.StartInfo.Arguments = "-u root --password=root world creature --result-file=" + @"updater\launcher\sql\NPCDelete\backup\NPCDeleteDump.sql";
                            mysqldump.StartInfo.UseShellExecute = true;
                            mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            mysqldump.Start();
                            mysqldump.WaitForExit();


                            var fullPath = Path.GetFullPath(@"updater\launcher\sql\NPCDelete\backup\NPCDeleteDump.sql");
                            var originalbackup = new FileInfo(@"updater\launcher\sql\CreatureSpawntime\backup\NPCDeleteDump_Original.sql");
                            if (!originalbackup.Exists)
                            { File.Copy(Path.Combine(@"updater\launcher\sql\NPCDelete\backup", "NPCDeleteDump.sql"), Path.Combine(@"updater\launcher\sql\NPCDelete\backup", "NPCDeleteDump_Original.sql")); }

                            DialogResult c;
                            c = MessageBox.Show("Backup was saved to " + fullPath, "NPCDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (c == DialogResult.OK)
                            {

                            }

                        }

                        var spawntime = new Process();
                        var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\NPCDelete\NPCDelete.sql";
                        spawntime.StartInfo.FileName = "cmd.exe";
                        spawntime.StartInfo.Arguments = spawntimestring;
                        spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        spawntime.Start();
                        spawntime.WaitForExit();

                        DialogResult d;
                        d = MessageBox.Show("Npc entry " + textBox1.Text + " spawns were removed.", "NPCDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                        {
                            Close();
                        }
                    }

                }
                else
                {
                    DialogResult checkifnum;
                    checkifnum = MessageBox.Show("You must enter a Number", "NPCDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (checkifnum == DialogResult.OK)
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
                    Close();
                }

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var restorefile = new FileInfo(@"updater\launcher\sql\NPCDelete\backup\NPCDeleteDump_Original.sql");

            if (restorefile.Exists)
            {
                var spawntime = new Process();
                var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\NPCDelete\backup\NPCDeleteDump_Original.sql";
                spawntime.StartInfo.FileName = "cmd.exe";
                spawntime.StartInfo.Arguments = spawntimestring;
                spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                spawntime.Start();
                spawntime.WaitForExit();


                DialogResult d;
                d = MessageBox.Show("Original creature table restored.", "NPCDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {
                    Close();
                }
            }
            else
            {

                DialogResult d;
                d = MessageBox.Show("You don't have a backup to restore", "NPCDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {
                    Close();
                }

            }

        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}




