using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Homework7
{
    public partial class Form1 : Form
    {
        OrderService OS = new OrderService();
       
        List<OrderDetails> orderlist = new List<OrderDetails>();
        
        
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

            //textBox1.DataBindings.Add("Text", orderlist, "OrderNum");
            //dataGridView1.DataBindings.Add("Text", orderlist, "orderNum");
            //dataGridView1.DataBindings.Add("Text", orderlist, "cName");
            //dataGridView1.DataBindings.Add("Text", orderlist, "pName");
            string username = "root";
            string password = "yezi99612";
            String connetStr = "server=127.0.0.1;port=3306;user=" + username + ";password=" + password + "; database=base1;";
            MySqlConnection conn = new MySqlConnection(connetStr);

            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                
                //在这里使用代码对数据库进行增删查改
                foreach (OrderDetails s in orderlist)
                {
                    String sql = "INSERT INTO orderCase VALUES ("
                        + s.OrderNum.ToString() + ','
                        + '\'' + s.CName + '\'' + ','
                        + '\'' + s.PName + '\'' + ','
                        + ");";
                    MySqlCommand sqlInsert = new MySqlCommand(sql, conn);
                    sqlInsert.ExecuteNonQuery();
                    sqlInsert.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            String num = textBox2.Text;
            OS.DeleteOrder(num, orderlist);
            string strConn = "server=localhost; user id=root; password=yezi99612; port=3306; database=t1";
            MySqlConnection myConn = new MySqlConnection(strConn);
            myConn.Open();
            string sql = @"delete from t_user where t_id = num";
            MySqlCommand cmd = new MySqlCommand(sql, myConn);
            int x = cmd.ExecuteNonQuery();
            myConn.Close();
            
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
            string strConn = "server=localhost; user id=root; password=yezi99612; port=3306; database=t1";
            MySqlConnection myConn = new MySqlConnection(strConn);
            myConn.Open();
            string sql = @"update t_user set t_CName='wangwu', t_PName='ww' where t_id=textBox1.Text";
            MySqlCommand cmd = new MySqlCommand(sql, myConn);
            int x = cmd.ExecuteNonQuery();
            myConn.Close();
           
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            
            String strConn = "server=localhost; user id=root; password=yezi99612; port=3306; database=t1";
            MySqlConnection myConn = new MySqlConnection(strConn);
            myConn.Open();
            string sql = @"insert into user(t_CName, t_PName) values(form2.name, form2.product)";
            MySqlCommand cmd = new MySqlCommand(sql, myConn);
            int num = cmd.ExecuteNonQuery();
            myConn.Close();
            //orderDetailsBindingSource.DataSource = orderlist;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            OS.ChangeOrder(form3.num, form3.changeway, form3.keyword, orderlist);
            //orderDetailsBindingSource.DataSource = orderlist;
        }

        //private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        //{

        //}
    }
}
