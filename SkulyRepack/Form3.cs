using System;
using System.Diagnostics;
using System.Runtime.InteropServices;   // For DLL importing
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SkulyRepack
{
    public partial class Form3 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public Form3()
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
                    SendKeys.Send("account set gmlevel " + textBox1.Text + " 3 -1");
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

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
