using System;
using System.Diagnostics;
using System.Runtime.InteropServices;   // For DLL importing
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form12 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Procworld = "worldserver";
            var procworld = Process.GetProcessesByName(Procworld);

            if ((procworld.Length != 0))
            {
                foreach (var proc in procworld)
                {
                    SetForegroundWindow(proc.MainWindowHandle);
                    SendKeys.Send("pdump load " + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text);
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

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_GotFocus(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            { textBox1.Text = " Filename/Character Name"; }
            else
            { textBox1.Text = textBox1.Text; }
        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {

            if (textBox2.Text.Length == 0)
            { textBox2.Text = "        Account Name"; }
            else
            { textBox2.Text = textBox2.Text; }
        }

        private void textBox3_LostFocus(object sender, EventArgs e)
        {

            if (textBox3.Text.Length == 0)
            { textBox3.Text = " New Name For Character"; }
            else
            { textBox3.Text = textBox3.Text; }
        }

    }
}
