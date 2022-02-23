using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;   // For DLL importing
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form11 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        public Form11()
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
                    SendKeys.Send("pdump write " + textBox1.Text + " " + textBox1.Text);
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

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            { textBox1.Text = "Character Name"; }
            else
            { textBox1.Text = textBox1.Text; }
            
        }

    }
}
