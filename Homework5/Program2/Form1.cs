using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            DrawTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        
       
        

        void DrawTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            int k = Int32.Parse(textBox1.Text);
            double per1 = Double.Parse(textBox2.Text);
            double per2 = Double.Parse(textBox3.Text);
            double th1 = Double.Parse(textBox4.Text) * Math.PI / 180;
            double th2 = Double.Parse(textBox5.Text) * Math.PI / 180;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * k * Math.Cos(th);
            double y2 = y0 + leng * k * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);
            DrawTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawTree(n - 1, x2, y2, per2 * leng, th - th2);
           
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            
            switch (comboBox1.Text)
            {
                case "Blue":
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    //graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x2, (int)y2);
                    break;
                case "Black":
                    graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
                    //graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x2, (int)y2);
                    break;
                case "Red":
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                   // graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x2, (int)y2);
                    break;
                case "Green":
                    graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
                   // graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x2, (int)y2);
                    break;
                case "Yellow":
                    graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1);
                    //graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x2, (int)y2);
                    break;

                default:
                    break;
            }

        }

        
    }
}
