using System;
using Market.Data.Configuration;
using Market.Entities.ShouldMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class RackUnitTest
    {
        [TestMethod]
        public void RackTest() 
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {
                    var ID = GetRack();
                    Rack rack = Session.Get<Rack>(ID);

                    Assert.AreEqual(rack.Id, ID);
                    Assert.AreEqual(rack.Name, "MARKAZI");

                }
            }
        }

        public Guid GetRack()
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {
                    Rack RACK1 = new Rack()
                    {
                        Name = "MARKAZI",
                        Limit = 10,
                        Location = "KARAJ",
                    };
                    RACK1.Rack1 = RACK1;



                    Session.Save(RACK1);

                    Transaction.Commit();

                    var Res = Session.Get<Rack>(RACK1.Id);
                    return Res.Id;

                }
            }
        }
    }
}
