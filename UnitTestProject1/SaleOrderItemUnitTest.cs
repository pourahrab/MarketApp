using System;
using Market.Data.Configuration;
using Market.Entities.ShouldMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class SaleOrderItemUnitTest
    {
        [TestMethod]
        public void SaleOrderItemTest() 
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {
                    var SaleID = GetSaleOrderItem();
                    SaleOrderItem SaleOrderItem1 = Session.Get<SaleOrderItem>(SaleID);
                    Assert.AreEqual(SaleID, SaleOrderItem1.Id); 

                }
            }


        }
        public Guid GetSaleOrderItem()
        { 
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {

                    ItemUnitTest itemTest = new ItemUnitTest();
                    RackUnitTest rackTest = new RackUnitTest();

                    var ItemId = itemTest.GetItem();
                    var RackId = rackTest.GetRack();

                    Item Item = Session.Get<Item>(ItemId);
                    Rack Rack = Session.Get<Rack>(RackId); 


                    SaleOrderItem SaleOrderItem1 = new SaleOrderItem()
                        {
                            Name = "khodkar",
                            QTY = 10,
                            NetPrice = 800,
                            TotalPrice = 10 * 800,
                            UnitPrice = 800,
                            Item1 = Item,
                            Rack1 = Rack
                        };

                    Session.Save(SaleOrderItem1);

                    Transaction.Commit();
                    var Res = Session.Get<Market.Entities.ShouldMap.SaleOrderItem>(SaleOrderItem1.Id);

                    return Res.Id;





                }
            }
        }
    }
}
