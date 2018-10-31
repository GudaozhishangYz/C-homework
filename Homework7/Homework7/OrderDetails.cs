using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    public class OrderDetails
    {
        public static int num = 0;
        public int OrderNum { get; set; }
        public String CName { get; set; }
        public String PName { get; set; }
        public OrderDetails(String cName, String pName)
        {
            num++;
            OrderNum = num;
            CName = cName;
            PName = pName;
        }


    }     
}

