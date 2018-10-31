using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    public class OrderService
    {


        List<OrderDetails> orderlist = new List<OrderDetails>();

        public void AddOrder(String CName, String PName)
        {

            OrderDetails order = new OrderDetails(CName, PName);

            orderlist.Add(order);

        }

        public void DeleteOrder(int num)
        {
            try
            {
                foreach (var item in orderlist)
                {
                    if (item.OrderNum == num)
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

        public void ChangeOrder(int num, int n, String ne)
        {
            foreach (var item in orderlist)
            {
                if (item.OrderNum == num)
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

        public void SearchOrder(int x, String v)
        {

            try
            {
                switch (x)
                {
                    case 1:
                        int n = Int32.Parse(v);
                        foreach (var item in orderlist)
                        {
                            if (item.OrderNum == n)
                            {

                                Console.WriteLine(item.OrderNum.ToString() + '\t' + item.CName + '\t' + item.PName);
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


    }
}
