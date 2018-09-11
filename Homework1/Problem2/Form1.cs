using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
          

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            int num1 = Int32.Parse(s);
            String n = textBox2.Text;
            int num2 = Int32.Parse(n);
            int mut = num1 * num2;
            label3.Text = "num1*num2=" + mut;
        }
    }
}
