using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form3 : Form
    {
        public int num;
        public string keyword;
        public int changeway;
        public Form3()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            changeway = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            changeway = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            num = Int32.Parse(textBox1.Text);
            keyword = textBox2.Text;
            this.Close();
        }
    }
}
