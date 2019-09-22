using System;
using Market.Data.Configuration;
using Market.Entities.ShouldMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class SaleOrderUnitTest
    {
        [TestMethod]
        public void SaleOrderTest()
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {

                    SaleOrderItemUnitTest SOrderItem = new SaleOrderItemUnitTest();
                    var SaleOrderItemID = SOrderItem.GetSaleOrderItem();


                    SaleOrderItem SaleOrderitem = Session.Get<SaleOrderItem>(SaleOrderItemID);


                    SaleOrder SaleOrder1 = new SaleOrder 
                    {
                        Title = "Ali",
                        CreationDate = DateTime.Now 
                    };

                    SaleOrder1.SaleorderItems.Add(SaleOrderitem);


                    Session.Save(SaleOrder1);
                    Transaction.Commit();

                    var res = Session.Get<SaleOrder>(SaleOrder1.Id);
                    Assert.AreEqual(res.Id, SaleOrder1.Id);
                }
            }
        }
    }
}
