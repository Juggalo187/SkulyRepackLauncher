using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo botmanual = new FileInfo(@"updater\launcher\BotsManual.html");
            if (botmanual.Exists)
            {
                System.Diagnostics.Process.Start(@"updater\launcher\BotsManual.html");
            }
            else
            {
                Directory.CreateDirectory(@"updater\launcher\");
                WebClient webClient = new WebClient();
                webClient.DownloadFile("https://raw.githubusercontent.com/Juggalo187/Repack_updater/main/BotsManual.html", @"updater\launcher\BotsManual.html");
                System.Diagnostics.Process.Start(@"updater\launcher\BotsManual.html");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String sqlcheck1 = "mysqld";
            Process[] sqlcheck2 = Process.GetProcessesByName(sqlcheck1);
            if ((sqlcheck2.Length == 0))
            {
                DialogResult b;
                b = MessageBox.Show("Would you like to make a backup before deleting spawned bots?", "NPCBotsDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (b == DialogResult.Yes)
                {
                    Directory.CreateDirectory(@"updater\launcher\sql\NPCDeleteBots\backup");
                    Process mysqldump = new Process();
                    mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                    mysqldump.StartInfo.Arguments = "-u root --password=root  world creature --result-file=" + @"updater\launcher\sql\NPCDeleteBots\backup\NPCBotsDump_world.sql";
                    mysqldump.StartInfo.UseShellExecute = true;
                    mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mysqldump.Start();
                    mysqldump.WaitForExit();
                    mysqldump.StartInfo.Arguments = "-u root --password=root characters characters_npcbot --result-file=" + @"updater\launcher\sql\NPCDeleteBots\backup\NPCBotsDump_chars.sql";
                    mysqldump.StartInfo.UseShellExecute = true;
                    mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mysqldump.Start();
                    mysqldump.WaitForExit();


                    String fullPath = Path.GetDirectoryName(@"updater\launcher\sql\NPCDeleteBots\backup\NPCBotsDump.sql");
                    FileInfo originalbackup = new FileInfo(@"updater\launcher\sql\NPCDeleteBots\backup\NPCBotsDump_Original.sql");
                    if (!originalbackup.Exists)
                    {
                        Directory.CreateDirectory(@"updater\launcher\sql\NPCDeleteBots\backup\original");
                        File.Copy(Path.Combine(@"updater\launcher\sql\NPCDeleteBots\backup", "NPCBotsDump_world.sql"), Path.Combine(@"updater\launcher\sql\NPCDeleteBots\backup\original", "NPCBotsDump_Original_world.sql"));
                        File.Copy(Path.Combine(@"updater\launcher\sql\NPCDeleteBots\backup", "NPCBotsDump_chars.sql"), Path.Combine(@"updater\launcher\sql\NPCDeleteBots\backup\original", "NPCBotsDump_Original_chars.sql"));
                    }

                    DialogResult c;
                    c = MessageBox.Show("Backup was saved to " + fullPath, "NPCBotsDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (c == DialogResult.OK)
                    {

                    }
                }
                Process deletebotschar = new Process();
                string deletebotscharstring = "/C " + @"MySQL\bin\mysql -u root --password=root characters < " + @"updater\launcher\sql\NPCDeleteBots\delete_npcbot_chars.sql";
                deletebotschar.StartInfo.FileName = "cmd.exe";
                deletebotschar.StartInfo.Arguments = deletebotscharstring;
                deletebotschar.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletebotschar.Start();
                deletebotschar.WaitForExit();

                Process deletebotsworld = new Process();
                string deletebotsworldstring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\NPCDeleteBots\delete_npcbot_world.sql";
                deletebotsworld.StartInfo.FileName = "cmd.exe";
                deletebotsworld.StartInfo.Arguments = deletebotsworldstring;
                deletebotsworld.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletebotsworld.Start();
                deletebotsworld.WaitForExit();

                DialogResult d;
                d = MessageBox.Show("ALL NPCBots should have been removed from the world.", "NPCBotsDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {

                }


            }
            else
                {

                DialogResult b;
                b = MessageBox.Show("Would you like to make a backup before deleting spawned bots?", "NPCBotsDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (b == DialogResult.Yes)
                {
                    Directory.CreateDirectory(@"updater\launcher\sql\NPCDeleteBots\backup");
                    Process mysqldump = new Process();
                    mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                    mysqldump.StartInfo.Arguments = "-u root --password=root world creature --result-file=" + @"updater\launcher\sql\NPCDeleteBots\backup\NPCBotsDump_world.sql";
                    mysqldump.StartInfo.UseShellExecute = true;
                    mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mysqldump.Start();
                    mysqldump.WaitForExit();
                    mysqldump.StartInfo.Arguments = "-u root --password=root characters characters_npcbot --result-file=" + @"updater\launcher\sql\NPCDeleteBots\backup\NPCBotsDump_chars.sql";
                    mysqldump.StartInfo.UseShellExecute = true;
                    mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mysqldump.Start();
                    mysqldump.WaitForExit();


                    String fullPath = Path.GetDirectoryName(@"updater\launcher\sql\NPCDeleteBots\backup\NPCBotsDump.sql");
                    FileInfo originalbackup = new FileInfo(@"updater\launcher\sql\NPCDeleteBots\backup\NPCBotsDump_Original_world.sql");
                    if (!originalbackup.Exists)
                    {
                      Directory.CreateDirectory(@"updater\launcher\sql\NPCDeleteBots\backup\original");
                      File.Copy(Path.Combine(@"updater\launcher\sql\NPCDeleteBots\backup", "NPCBotsDump_world.sql"), Path.Combine(@"updater\launcher\sql\NPCDeleteBots\backup\original", "NPCBotsDump_Original_world.sql"));
                      File.Copy(Path.Combine(@"updater\launcher\sql\NPCDeleteBots\backup", "NPCBotsDump_chars.sql"), Path.Combine(@"updater\launcher\sql\NPCDeleteBots\backup\original", "NPCBotsDump_Original_chars.sql"));
                    }

                    DialogResult c;
                    c = MessageBox.Show("Backup was saved to " + fullPath, "NPCBotsDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (c == DialogResult.OK)
                    {

                    }
                }
                Process deletebotschar = new Process();
                string deletebotscharstring = "/C " + @"MySQL\bin\mysql -u root --password=root characters < " + @"updater\launcher\sql\NPCDeleteBots\delete_npcbot_chars.sql";
                deletebotschar.StartInfo.FileName = "cmd.exe";
                deletebotschar.StartInfo.Arguments = deletebotscharstring;
                deletebotschar.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletebotschar.Start();
                deletebotschar.WaitForExit();

                Process deletebotsworld = new Process();
                string deletebotsworldstring = "/C " + @"MySQL\bin\mysql -u root --password=root world < " + @"updater\launcher\sql\NPCDeleteBots\delete_npcbot_world.sql";
                deletebotsworld.StartInfo.FileName = "cmd.exe";
                deletebotsworld.StartInfo.Arguments = deletebotsworldstring;
                deletebotsworld.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                deletebotsworld.Start();
                deletebotsworld.WaitForExit();

                DialogResult d;
                d = MessageBox.Show("ALL NPCBots should have been removed from the world.", "NPCBotsDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {

                }

            }
        }
            



        }
    }
