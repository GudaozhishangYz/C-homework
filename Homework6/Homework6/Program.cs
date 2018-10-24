using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Homework6
{
    public class OrderDetails
    {
        public static int num = 0;
        public int orderNum = 0;
        public String cName;
        public String pName;
        public OrderDetails()
        {
            num++;
            orderNum = num;
        }
        public void OrderCreat(String CName, String PName)
        {
            cName = CName;
            pName = PName;

        }
    }

    class Order
    {
        OrderService orderservice = new OrderService();
        public void OrderS(int x)
        {
            List<OrderDetails> orderlist = new List<OrderDetails>();

            switch (x)
            {
                case 1:
                    Console.WriteLine("please input name:");
                    String CName = Console.ReadLine();
                    Console.WriteLine("please input production:");
                    String PName = Console.ReadLine();
                    orderservice.AddOrder(CName, PName);
                    break;
                case 2:
                    Console.WriteLine("please input number:");
                    String s = Console.ReadLine();
                    int num = Int32.Parse(s);
                    orderservice.DeleteOrder(num);
                    break;
                case 3:
                    Console.WriteLine("please input number:");
                    String s1 = Console.ReadLine();
                    int num2 = Int32.Parse(s1);
                    Console.WriteLine("1(change name) 2(change production)");
                    String s2 = Console.ReadLine();
                    int n = Int32.Parse(s2);
                    String ne = Console.ReadLine();
                    orderservice.ChangeOrder(num2, n, ne);
                    break;
                case 4:
                    Console.WriteLine("1(search num)、2(search name)、3(search production)");
                    int x2 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Please input key word:");
                    String v = Console.ReadLine();
                    Console.WriteLine("number\tname\tproduction");
                    orderservice.SearchOrder(x2, v);
                    break;
                case 5:
                    orderservice.Export();
                    break;
                case 6:
                    orderservice.Import(orderlist);
                    break;
            }
        }



    }

    public class OrderService
    {
        List<OrderDetails> orderlist = new List<OrderDetails>();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<OrderDetails>));
        public void AddOrder(String CName, String PName)
        {
           
            OrderDetails order = new OrderDetails();
            order.OrderCreat(CName, PName);
            orderlist.Add(order);

        }

        public void DeleteOrder(int num)
        {
            try
            {
                
                orderlist.Remove(orderlist[num - 1]);
            }
            catch
            {
                
                Console.WriteLine("404 not found!!!");

            }
        }

        public void ChangeOrder(int num, int n, String ne)
        {
            
            switch (n)
            {
                case 1:
                    orderlist[num - 1].cName = ne;
                    break;
                case 2:
                    orderlist[num - 1].pName = ne;
                    break;


            }



        }

        public void SearchOrder(int x, String v)
        {
           
            try
            {
                switch (x)
                {
                    case 1:
                        int n = Int32.Parse(v);
                        Console.WriteLine(orderlist[n - 1].orderNum.ToString() + '\t' + orderlist[n - 1].cName + '\t' + orderlist[n - 1].pName);

                        break;
                    case 2:
                        String m = v;
                        foreach (var item in orderlist)
                        {
                            if (item.cName.Equals(m))
                            {
                                Console.WriteLine(item.orderNum.ToString() + '\t' + item.cName + '\t' + item.pName);
                            }
                        }
                        break;
                    case 3:
                        String k = v;
                        foreach (var item in orderlist)
                        {
                            if (item.pName.Equals(k))
                            {
                                Console.WriteLine(item.orderNum.ToString() + '\t' + item.cName + '\t' + item.pName);
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

        public void Export()
        {
           
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderlist);
            }

            Console.WriteLine(File.ReadAllText("s.xml"));       

        }

        public void Import(List<OrderDetails> orderlist2)
        {
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                orderlist2 = (List<OrderDetails>)xmlSerializer.Deserialize(fs);    
            }
            foreach (var p in orderlist2)
            {
                Console.WriteLine(p);
            }
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
