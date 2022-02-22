using System;
using System.Diagnostics;
using System.Runtime.InteropServices;   // For DLL importing
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SkulyRepack
{
    public partial class Form2 : Form
    {

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);



        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Procworld = "worldserver";
            Process[] procworld = Process.GetProcessesByName(Procworld);


            if ((procworld.Length != 0))
            {
                foreach (Process proc in procworld)
                {
                   SetForegroundWindow(proc.MainWindowHandle);
                    SendKeys.Send("account create " + textBox1.Text + " " + textBox2.Text);
                    SendKeys.Send("{ENTER}");
                }
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("WorldServer is not started", "Start Worldserver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {
                    Close();
                }
            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
