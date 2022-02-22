using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Process killmysql1 = new Process();
            string killmysqld1 = "/C " + "taskkill /f /im mysqld.exe";
            killmysql1.StartInfo.FileName = "cmd.exe";
            killmysql1.StartInfo.Arguments = killmysqld1;
            killmysql1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            killmysql1.Start();
            killmysql1.WaitForExit();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {

                String Procmysql = "mysqld";
                Process[] procmysqld = Process.GetProcessesByName(Procmysql);

                if ((procmysqld.Length != 0))
                {
                    button1.Visible = false;
                    Controls.Add(progressBar1);
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 7;

                    string path = @"MySQL\bin\AccountBackup";
                    DirectoryInfo di = Directory.CreateDirectory(path);

                    progressBar1.Value = 1;
                    Process mysqldump = new Process();

                    mysqldump.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                    mysqldump.StartInfo.Arguments = "-u root --password=root auth account account_access account_banned account_muted realmcharacters --result-file=" + @"MySQL\bin\AccountBackup\AuthDB.sql";

                    mysqldump.StartInfo.UseShellExecute = true;
                    mysqldump.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mysqldump.Start();
                    mysqldump.WaitForExit();
                    progressBar1.Value = 2;

                    Process mysqldump2 = new Process();
                    mysqldump2.StartInfo.FileName = @"MySQL\bin\mysqldump.exe";
                    mysqldump2.StartInfo.Arguments = "--skip-lock-tables -f -u root --password=root characters character_glyphs account_data account_instance_times account_tutorial arena_team arena_team_member auctionbidders auctionhouse character_account_data character_achievement character_achievement_progress character_action character_arena_stats character_aura character_banned character_battleground_data character_battleground_random character_declinedname character_equipmentsets character_fishingsteps character_gifts character_homebind character_instance character_inventory character_pet character_pet_declinedname character_queststatus character_queststatus_daily character_queststatus_monthly character_queststatus_rewarded character_queststatus_seasonal character_queststatus_weekly character_reputation character_skills character_social character_spell character_spell_cooldown character_stats character_talent characters corpse custom_item_enchant_visuals custom_transmogrification group_instance group_member groups guild guild_bank_eventlog guild_bank_item guild_bank_right guild_bank_tab guild_eventlog guild_member guild_member_withdraw guild_rank instance_reset item_instance item_refund_instance item_soulbound_trade_data mail mail_items pet_aura pet_spell pet_spell_cooldown character_glyphs --result-file=" + @"MySQL\bin\AccountBackup\CharactersDB.sql";
                    mysqldump2.StartInfo.UseShellExecute = true;
                    mysqldump2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mysqldump2.Start();
                    mysqldump2.WaitForExit();
                    progressBar1.Value = 3;


                    Process killmysql = new Process();
                    string killmysqld = "/C " + "taskkill /f /im mysqld.exe";
                    killmysql.StartInfo.FileName = "cmd.exe";
                    killmysql.StartInfo.Arguments = killmysqld;
                    killmysql.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    killmysql.Start();
                    killmysql.WaitForExit();
                    progressBar1.Value = 4;


                    foreach (var process in Process.GetProcessesByName("cmd"))
                    {

                        if (process.MainWindowTitle == "MySQL 5.7.30" || process.MainWindowTitle == "Administrator: MySQL 5.7.30")
                        {
                            process.Kill();
                        }

                    }

                    Process mysqld = new Process();
                    mysqld.StartInfo.FileName = @"MySQL\bin\mysqld.exe";
                    mysqld.StartInfo.Arguments = "--console";
                    mysqld.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    mysqld.Start();


                    progressBar1.Value = 5;
                    Process mysql = new Process();
                    string command1 = "/C " + @"MySQL\bin\mysql -u root --password=root auth <" + @"MySQL\bin\AccountBackup\AuthDB.sql";
                    mysql.StartInfo.FileName = "cmd.exe";
                    mysql.StartInfo.Arguments = command1;
                    mysql.StartInfo.UseShellExecute = true;
                    mysql.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mysql.Start();
                    mysql.WaitForExit();
                    progressBar1.Value = 6;

                    Process mysql2 = new Process();
                    string command2 = "/C " + @"MySQL\bin\mysql -u root --password=root characters <" + @"MySQL\bin\AccountBackup\CharactersDB.sql";
                    mysql2.StartInfo.FileName = "cmd.exe";
                    mysql2.StartInfo.Arguments = command2;
                    mysql2.StartInfo.UseShellExecute = true;
                    mysql2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    mysql2.Start();
                    mysql2.WaitForExit();
                    button1.Visible = true;
                    button1.Text = "Done";
                    progressBar1.Value = 7;

                }

                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Please Start the MySQL server of the Repack you want to transfer data from.", "Start MySQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (d == DialogResult.OK)
                    {

                    }
                }



            }
            else
            {
                Close();
            }




        }
    }
}
