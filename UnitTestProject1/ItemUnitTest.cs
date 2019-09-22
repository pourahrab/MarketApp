using System;
using Market.Data.Configuration;
using Market.Entities.ShouldMap;
using Market.Entities.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ItemUnitTest
    {
        [TestMethod]
        public void ItemTest() 
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {
                    var ID = GetItem();
                    Item item = Session.Get<Item>(ID);



                    Assert.AreEqual(item.Id, ID);


                }
            }

        }

        public Guid GetItem()
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {
                    Item ITEM1 = new Item()
                    {
                        Name = "khodkar",
                        Unit = UnitType.Number,
                    };
                    Session.Save(ITEM1);

                    Transaction.Commit();
                    var Res = Session.Get<Item>(ITEM1.Id);
                    return Res.Id;

                }

            }
        }
    }
}
