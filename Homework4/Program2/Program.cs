using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class OrderDetails
    {
        public static int num = 0;
        public  int orderNum = 0;
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
            switch (x)
            {
                case 1:
                    orderservice.AddOrder();
                    break;
                case 2:
                    orderservice.DeleteOrder();
                    break;
                case 3:
                    orderservice.ChangeOrder();
                    break;
                case 4:
                    orderservice.SearchOrder();
                    break;
            }
        }
        

        
    }

    class OrderService
    {
        List<OrderDetails> orderlist = new List<OrderDetails>();
        public void AddOrder()
        {
            Console.WriteLine("please input name:");
            String CName = Console.ReadLine();
            Console.WriteLine("please input production:");
            String PName = Console.ReadLine();
            OrderDetails order = new OrderDetails();
            order.OrderCreat(CName, PName);
            orderlist.Add(order);

        }

        public void DeleteOrder()
        {
            try
            {
                String s = Console.ReadLine();
                int num = Int32.Parse(s);
                orderlist.Remove(orderlist[num - 1]);
            }
            catch
            {
                Console.WriteLine("404 not found!!!");

            }
        }

        public void ChangeOrder()
        {
            String s1 = Console.ReadLine();
            int num = Int32.Parse(s1);
            Console.WriteLine("1(change name) 2(change production)");
            String s2 = Console.ReadLine();
            int n = Int32.Parse(s2);
            String ne = Console.ReadLine();
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

        public void SearchOrder()
        {
            Console.WriteLine("1(search num)、2(search name)、3(search production)");
            int x = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please input key word:");
            String v = Console.ReadLine();
            Console.WriteLine("number\tname\tproduction");
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to use our order system!");
            Order order = new Order();
            while (true)
            {
                Console.WriteLine("1(add)  2(delete) 3(change) 4(search)");
                int x=Int32.Parse(Console.ReadLine());
                order.OrderS(x);
            }
        }
    }
}
