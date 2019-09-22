using System;
using Market.Data.Configuration;
using Market.Entities.ShouldMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PurchaseOrderUnitTest
    {
        [TestMethod]
        public void PurchaseOrderTest() 
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {
                    PurchaseOrderItemUnitTest purchaseOrderItem1 = new PurchaseOrderItemUnitTest();
                    var POrderItemID = purchaseOrderItem1.GetPurchaseOrderItem();


                   
                    PurchaseOrderItem purchaseOrderitem1 = Session.Get<PurchaseOrderItem>(POrderItemID);


                    PurchaseOrder PurchaseOrder1 = new PurchaseOrder 
                    {
                        Title = "Ali",
                        CreationDate = DateTime.Now
                    };
                    PurchaseOrder1.PurchaseOrderItems.Add(purchaseOrderitem1);


                    Session.Save(PurchaseOrder1);
                    Transaction.Commit();


                    var res = Session.Get<PurchaseOrder>(PurchaseOrder1.Id);
                    Assert.AreEqual(res.Id, PurchaseOrder1.Id);
                }
            }
        }
    }
}
