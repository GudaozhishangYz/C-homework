using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    public class OrderService
    {


       
        public void AddOrder(String CName, String PName,  List<OrderDetails> orderlist)
        {

            OrderDetails order = new OrderDetails(CName, PName);

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
                if (item.OrderNum.Equals(num))
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


    }
}
