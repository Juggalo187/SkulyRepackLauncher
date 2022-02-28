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
        private static extern bool SetForegroundWindow(IntPtr hWnd);



        public Form2()
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

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            { textBox1.Text = "Account name"; }
            else
            { textBox1.Text = textBox1.Text; }



        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {

            if (textBox2.Text.Length == 0)
            { textBox2.Text = "Password"; }
            else
            { textBox2.Text = textBox2.Text; }
        }
    }
}
