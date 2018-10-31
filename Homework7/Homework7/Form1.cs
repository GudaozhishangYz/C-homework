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
    public partial class Form1 : Form
    {
        OrderService OS = new OrderService();
       
        List<OrderDetails> orderlist = new List<OrderDetails>();
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        //BindingSource orderDetailsBindingSource = new BindingSource();
        public int way;

        public void  Chooseways()
        {
            switch (comboBox1.SelectedText)
            {
                case "OrderNum":
                    way = 1;
                    break;
                case "Name":
                    way = 2;
                    break;
                case "Product":
                    way = 3;
                    break;
                default:
                    break;
            }
        }
        public Form1()
        {
            InitializeComponent();

            orderlist.Add(new OrderDetails("Jerry", "Egg"));
            orderDetailsBindingSource.DataSource = orderlist;
           
            textBox1.DataBindings.Add("Text", orderlist, "OrderNum");
            //dataGridView1.DataBindings.Add("Text", orderlist, "orderNum");
            //dataGridView1.DataBindings.Add("Text", orderlist, "cName");
            //dataGridView1.DataBindings.Add("Text", orderlist, "pName");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
            //OS.AddOrder(form2.name, form2.product);
            //orderDetailsBindingSource.DataSource = orderlist;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = Int32.Parse(textBox2.Text);
            OS.DeleteOrder(num);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form3.ShowDialog();
            OS.ChangeOrder(form3.num, form3.changeway, form3.keyword);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Chooseways();
            switch (way)
            {
                case 1:
                    orderDetailsBindingSource.DataSource = orderlist.Where(s => s.OrderNum == Int32.Parse(textBox1.Text));
                    break;
                case 2:
                    orderDetailsBindingSource.DataSource = orderlist.Where(s => s.CName == textBox1.Text);
                    break;
                case 3:
                    orderDetailsBindingSource.DataSource = orderlist.Where(s => s.PName == textBox1.Text);
                    break;
                default:
                    break;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            form2.ShowDialog();
            OS.AddOrder(form2.name, form2.product);
            orderDetailsBindingSource.DataSource = orderlist;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            form3.ShowDialog();
            OS.ChangeOrder(form3.num, form3.changeway, form3.keyword);
            orderDetailsBindingSource.DataSource = orderlist;
        }

        //private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        //{

        //}
    }
}
