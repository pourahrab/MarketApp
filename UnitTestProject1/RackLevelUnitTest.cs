using System;
using Market.Data.Configuration;
using Market.Entities.ShouldMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class RackLevelUnitTest
    {
        [TestMethod]
        public void RackLevelTest() 
        {

            using (var session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = session.BeginTransaction())
                {
                    var ID = GetRackLevl();

                    RackItemLevel rackItemLevel = session.Get<RackItemLevel>(ID);

                    Assert.AreEqual(ID, rackItemLevel.Id);

                }
            }
        }

        public Guid GetRackLevl()
        {

            using (var session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = session.BeginTransaction())
                {
                    ItemUnitTest itemtest = new ItemUnitTest();
                    RackUnitTest racktest = new RackUnitTest();

                    var item1 = itemtest.GetItem();
                    var rack1 = racktest.GetRack();

                    Item Item = session.Get<Item>(item1);
                    Rack Rack = session.Get<Rack>(rack1);

                    RackItemLevel RackItemLevel = new RackItemLevel()
                    {
                        CurrentQty = 6,
                        InQty = 10,
                        OutQty = 4,
                        Item1 = Item,
                        Rack1 = Rack
                    };
                    session.Save(RackItemLevel);

                    Transaction.Commit();

                    var Res = session.Get<RackItemLevel>(RackItemLevel.Id);
                    return Res.Id;

                }
            }
        }
    }
}
