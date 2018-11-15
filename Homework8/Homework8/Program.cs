using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Homework8
{
    public class OrderDetails
    {
        public static int num = 0;
        public String OrderNum { get; set; }
        public String CName { get; set; }
        public String PName { get; set; }
        public String Phone { get; set; }
        public OrderDetails()
        {

        }
        public OrderDetails(String cName, String pName,String phone)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            num++;
            OrderNum = year.ToString() + month.ToString() + day.ToString() + num.ToString();
            CName = cName;
            PName = pName;
            Phone = phone;
        }

    }

    class Order
    {
        public List<OrderDetails> orderlist = new List<OrderDetails>();
        OrderService orderservice = new OrderService();
        public void OrderS(int x)
        {
            
            switch (x)
            {
                case 1:
                    Console.WriteLine("please input name:");
                    String CName = Console.ReadLine();
                    Console.WriteLine("please input production:");
                    String PName = Console.ReadLine();
                    Console.WriteLine("please input phone:");
                    String Phone = Console.ReadLine();
                    orderservice.AddOrder(CName, PName, Phone, orderlist);
                    break;
                case 2:
                    Console.WriteLine("please input ordernumber:");
                    String s = Console.ReadLine();
                    orderservice.DeleteOrder(s, orderlist);
                    break;
                case 3:
                    Console.WriteLine("please input number:");
                    String s1 = Console.ReadLine();
                    Console.WriteLine("1(change name) 2(change production)");
                    String s2 = Console.ReadLine();
                    int n = Int32.Parse(s2);
                    String ne = Console.ReadLine();
                    orderservice.ChangeOrder(s1, n, ne, orderlist);
                    break;
                case 4:
                    Console.WriteLine("1(search num)、2(search name)、3(search production)");
                    int x2 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Please input key word:");
                    String v = Console.ReadLine();
                    Console.WriteLine("number\tname\tproduction");
                    orderservice.SearchOrder(x2, v, orderlist);
                    break;
                case 5:
                    orderservice.Export(orderlist);
                    break;
                case 6:
                    orderservice.Import(orderlist);
                    break;
            }
        }

    }

    public class OrderService
    {
        
        public XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<OrderDetails>));
        public void AddOrder(String CName, String PName, String Phone, List<OrderDetails> orderlist)
        {

            OrderDetails order = new OrderDetails(CName, PName, Phone);

            orderlist.Add(order);

        }

        public void DeleteOrder(String num, List<OrderDetails> orderlist)
        {
            try
            {
                foreach (var item in orderlist)
                {
                    if (item.OrderNum.Equals(num))
                    {
                        orderlist.Remove(item);
                    }
                }

            }
            catch
            {

                Console.WriteLine("404 not found!!!");

            }
        }

        public void ChangeOrder(String num, int n, String ne, List<OrderDetails> orderlist)
        {
            foreach (var item in orderlist)
            {
                if (item.OrderNum .Equals(num))
                {
                    switch (n)
                    {
                        case 1:
                            item.CName = ne;
                            break;
                        case 2:
                            item.PName = ne;
                            break;


                    }
                }
            }

        }

        public void SearchOrder(int x, String v, List<OrderDetails> orderlist)
        {

            try
            {
                switch (x)
                {
                    case 1:
                        foreach (var item in orderlist)
                        {
                            if (item.OrderNum.Equals(v))
                            {

                                Console.WriteLine(item.OrderNum + '\t' + item.CName + '\t' + item.PName);
                            }
                        }


                        break;
                    case 2:
                        String m = v;
                        foreach (var item in orderlist)
                        {
                            if (item.CName.Equals(m))
                            {
                                Console.WriteLine(item.OrderNum.ToString() + '\t' + item.CName + '\t' + item.PName);
                            }
                        }
                        break;
                    case 3:
                        String k = v;
                        foreach (var item in orderlist)
                        {
                            if (item.PName.Equals(k))
                            {
                                Console.WriteLine(item.OrderNum.ToString() + '\t' + item.CName + '\t' + item.PName);
                            }
                        }
                        break;
                }
            }
            catch
            {
                Console.WriteLine("404 not found!!!");

            }


        }

        public void Export(List<OrderDetails> orderlist)
        {

            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderlist);
            }

            Console.WriteLine(File.ReadAllText("s.xml"));

            XmlDocument doc = new XmlDocument();
            doc.Load(@".\s.xml");
            XPathNavigator nav = doc.CreateNavigator();
            nav.MoveToRoot();
            XslCompiledTransform xt = new XslCompiledTransform();
            xt.Load(@".\s.xsl");
            

            FileStream outFileStream = File.OpenWrite(@"..\..\orderList.html");
            XmlTextWriter writer =
                new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
            xt.Transform(nav, null, writer);


        }

        public void Import(List<OrderDetails> orderlist)
        {
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                orderlist = (List<OrderDetails>)xmlSerializer.Deserialize(fs);
            }
            foreach (var p in orderlist)
            {
                Console.WriteLine(p);
            }
        }

        public bool DataCheck(List<OrderDetails> orderlist)
        {
            Regex regex = new Regex("^1[0~9]+$");
            foreach (var item in orderlist)
            {
                if (!regex.IsMatch(item.Phone))
                {
                    return false;
                }
 
            }
            return true;
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to use our order system!");
            Order order = new Order();
            while (true)
            {
                Console.WriteLine("1(add)  2(delete) 3(change) 4(search) 5(export) 6(import)");
                int x = Int32.Parse(Console.ReadLine());
                order.OrderS(x);
            }
        }
    }
}
