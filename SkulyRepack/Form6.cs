using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace SkulyRepack
{
    public partial class Form6 : Form
    {
        public Form6()
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
                        //String createText = "SET @Spawntime = " + textBox1.Text + ";" + Environment.NewLine + "UPDATE creature SET spawntimesecs = @Spawntime WHERE npcflag = 0 AND (map = 0 OR map = 1 OR map = 530 OR map = 571);";
                        var createText = "SET @Spawntime = " + textBox1.Text + ";";
                        Directory.CreateDirectory(@"updater\launcher\sql\CreatureSpawntime\backup");
                        File.WriteAllText(@"updater\launcher\sql\CreatureSpawntime\execute.sql", createText, Encoding.UTF8);


                        DialogResult b;
                        b = MessageBox.Show("Would you like to make a backup before saving?", "Creature Respawn", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (b == DialogResult.Yes)
                        {
                            var mysqldump = new Process();
                            mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                            mysqldump.StartInfo.Arguments = "-u root --password=root world creature --result-file=" + @"updater\launcher\sql\CreatureSpawntime\backup\creatureDump.sql";
                            mysqldump.StartInfo.UseShellExecute = true;
                            mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            mysqldump.Start();
                            mysqldump.WaitForExit();


                            var fullPath = Path.GetFullPath(@"updater\launcher\sql\CreatureSpawntime\backup\creatureDump.sql");
                            var originalbackup = new FileInfo(@"updater\launcher\sql\CreatureSpawntime\backup\creatureDump_Original.sql");
                            if (!originalbackup.Exists)
                            { File.Copy(Path.Combine(@"updater\launcher\sql\CreatureSpawntime\backup", "creatureDump.sql"), Path.Combine(@"updater\launcher\sql\CreatureSpawntime\backup", "creatureDump_Original.sql")); }

                            DialogResult c;
                            c = MessageBox.Show("Backup was saved to " + fullPath, "Creature Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (c == DialogResult.OK)
                            {

                            }

                        }

                        var text = System.IO.File.ReadAllText(@"updater\launcher\sql\CreatureSpawntime\execute2.sql");
                        var appendText = text;
                        File.AppendAllText(@"updater\launcher\sql\CreatureSpawntime\execute.sql", appendText);


                        var spawntime = new Process();
                        var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\CreatureSpawntime\execute.sql";
                        spawntime.StartInfo.FileName = "cmd.exe";
                        spawntime.StartInfo.Arguments = spawntimestring;
                        spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        spawntime.Start();
                        spawntime.WaitForExit();


                        DialogResult d;
                        d = MessageBox.Show("Most npc's should now respawn " + textBox1.Text + " seconds after being killed.", "Creature Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                        {
                            Close();
                        }



                    }
                    else
                    {
                        DialogResult checkifnum;
                        checkifnum = MessageBox.Show("You must enter a Number", "Creature Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        //String createText = "SET @Spawntime = " + textBox1.Text + ";" + Environment.NewLine + "UPDATE creature SET spawntimesecs = @Spawntime WHERE npcflag = 0 AND (map = 0 OR map = 1 OR map = 530 OR map = 571);";

                        var createText = "SET @Spawntime = " + textBox1.Text + ";";
                        Directory.CreateDirectory(@"updater\launcher\sql\CreatureSpawntime\backup");
                        File.WriteAllText(@"updater\launcher\sql\CreatureSpawntime\execute.sql", createText, Encoding.UTF8);


                        DialogResult b;
                        b = MessageBox.Show("Would you like to make a backup before saving?", "Creature Respawn", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (b == DialogResult.Yes)
                        {
                            var mysqldump = new Process();
                            mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                            mysqldump.StartInfo.Arguments = "-u root --password=root world creature --result-file=" + @"updater\launcher\sql\CreatureSpawntime\backup\creatureDump.sql";
                            mysqldump.StartInfo.UseShellExecute = true;
                            mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            mysqldump.Start();
                            mysqldump.WaitForExit();

                            var fullPath = Path.GetFullPath(@"updater\launcher\sql\CreatureSpawntime\backup\creatureDump.sql");
                            var originalbackup = new FileInfo(@"updater\launcher\sql\CreatureSpawntime\backup\creatureDump_Original.sql");
                            if (!originalbackup.Exists)
                            { File.Copy(Path.Combine(@"updater\launcher\sql\CreatureSpawntime\backup", "creatureDump.sql"), Path.Combine(@"updater\launcher\sql\CreatureSpawntime\backup", "creatureDump_Original.sql")); }

                            DialogResult c;
                            c = MessageBox.Show("Backup was saved to " + fullPath, "Creature Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (c == DialogResult.OK)
                            {

                            }
                        }

                        var text = System.IO.File.ReadAllText(@"updater\launcher\sql\CreatureSpawntime\execute2.sql");
                        var appendText = text;
                        File.AppendAllText(@"updater\launcher\sql\CreatureSpawntime\execute.sql", appendText);

                        var spawntime = new Process();
                        var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\CreatureSpawntime\execute.sql";
                        spawntime.StartInfo.FileName = "cmd.exe";
                        spawntime.StartInfo.Arguments = spawntimestring;
                        spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        spawntime.Start();
                        spawntime.WaitForExit();


                        DialogResult d;
                        d = MessageBox.Show("Most npc's should now respawn " + textBox1.Text + " seconds after being killed.", "Creature Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                        {
                            Close();
                        }



                    }
                    else
                    {
                        DialogResult checkifnum;
                        checkifnum = MessageBox.Show("You must enter a Number", "Creature Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var restorefile = new FileInfo(@"updater\launcher\sql\CreatureSpawntime\backup\creatureDump_Original.sql");

            if (restorefile.Exists)
            {
                var spawntime = new Process();
                var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\CreatureSpawntime\backup\creatureDump_Original.sql";
                spawntime.StartInfo.FileName = "cmd.exe";
                spawntime.StartInfo.Arguments = spawntimestring;
                spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                spawntime.Start();
                spawntime.WaitForExit();


                DialogResult d;
                d = MessageBox.Show("Original creature table restored.", "Creature Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {
                    Close();
                }
            }
            else
            {

                DialogResult d;
                d = MessageBox.Show("You don't have a backup to restore", "Creature Respawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
