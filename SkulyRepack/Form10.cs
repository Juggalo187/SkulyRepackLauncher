using System;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var f4 = new Form4();
            f4.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var f3 = new Form3();
            f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f12 = new Form12();
            f12.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f11 = new Form11();
            f11.ShowDialog();
        }
    }
}
