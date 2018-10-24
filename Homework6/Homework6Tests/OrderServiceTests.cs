using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    
    [TestClass()]
    public class OrderServiceTests
    {

        List<OrderDetails> orderlist = new List<OrderDetails>();
        OrderService orderservicetest = new OrderService();
        [TestMethod()]
        public void AddOrderTest()
        {
            OrderDetails A = new OrderDetails();
            A.pName = "egg";
            A.cName = "Jerry";
            orderservicetest.AddOrder("Jerry", "egg");
            Assert.AreEqual(A.cName, orderlist[0].cName);
            Assert.AreEqual(A.pName, orderlist[0].pName);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            orderservicetest.DeleteOrder(1);
            Assert.IsNull(orderlist[1]);
            
        }

        [TestMethod()]
        public void ChangeOrderTest()
        {
            orderservicetest.AddOrder("Andy", "milk");
            orderservicetest.ChangeOrder(1, 1, "Mike");
            Assert.AreEqual(orderlist[0].cName, "Mike");
            orderservicetest.ChangeOrder(1, 2, "Chicken");
            Assert.AreEqual(orderlist[0].pName, "Chicken");
        }

        //[TestMethod()]
        //public void SearchOrderTest()
        //{

        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ExportTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ImportTest()
        //{
        //    Assert.Fail();
        //}
    }
}