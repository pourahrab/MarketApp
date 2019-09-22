using System;
using Market.Data.Configuration;
using Market.Entities.ShouldMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PurchaseOrderItemUnitTest
    {
        [TestMethod]
        public void PurchaseOrderItemTest() 
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {

                    var PurchaseID = GetPurchaseOrderItem();
                    PurchaseOrderItem PurchaseOrderItem1 = Session.Get<PurchaseOrderItem>(PurchaseID);
                    Assert.AreEqual(PurchaseID, PurchaseOrderItem1.Id);
                }
            }

        }
        public Guid GetPurchaseOrderItem()
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {

                    ItemUnitTest itemTest = new ItemUnitTest();
                    RackUnitTest rackTest = new RackUnitTest();

                    var ItemId = itemTest.GetItem(); 
                    var RackId = rackTest.GetRack();
                     
                    Item item = Session.Get<Item>(ItemId);
                    Rack rack = Session.Get<Rack>(RackId);


                    Market.Entities.ShouldMap.PurchaseOrderItem PurchaseOrderItem1 =
                        new Market.Entities.ShouldMap.PurchaseOrderItem()
                        {
                            Name = "khodkar",
                            QTY = 10,
                            NetPrice = 800,
                            TotalPrice = 10 * 800,
                            UnitPrice = 800,
                            Item1 = item,
                            //Rack1 = rack
                        };
                   
                    Session.Save(PurchaseOrderItem1);

                    Transaction.Commit();
                    var Res = Session.Get<Market.Entities.ShouldMap.PurchaseOrderItem>(PurchaseOrderItem1.Id);

                    return Res.Id;



                }
            }
        }
    }

}
