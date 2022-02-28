using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;   // For DLL importing
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form11 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public Form11()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var procworldstring = "worldserver";
            var procworld = Process.GetProcessesByName(procworldstring);

            if ((procworld.Length != 0))
            {

                var dumpfile = new FileInfo(@"" + textBox1.Text);


                foreach (var proc in procworld)
                {
                    if (dumpfile.Exists)
                    {
                        DialogResult f;
                        f = MessageBox.Show("The file " + textBox1.Text + " already exists, it will be deleted. Do you wish to proceed?", "Save Character", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (f == DialogResult.Yes)
                        {
                            File.Delete(@"" + textBox1.Text);
                            SetForegroundWindow(proc.MainWindowHandle);
                            SendKeys.Send("pdump write " + textBox1.Text + " " + textBox1.Text);
                            SendKeys.Send("{ENTER}");
                        }
                        else
                        {
                            Close();
                        }



                    }
                    else
                    {
                        SetForegroundWindow(proc.MainWindowHandle);
                        SendKeys.Send("pdump write " + textBox1.Text + " " + textBox1.Text);
                        SendKeys.Send("{ENTER}");
                    }


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

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            { textBox1.Text = "Character Name"; }
            else
            { textBox1.Text = textBox1.Text; }

        }

    }
}
