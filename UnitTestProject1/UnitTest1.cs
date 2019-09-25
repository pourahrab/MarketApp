using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Market.Data.Configuration;
using Market.Entities.ShouldMap;
using Market.Entities.Utility;
using NHibernate.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTest()
        {
            using (var Session = NhibernateLayer.OpenSession())
            {
                using (var Transaction = Session.BeginTransaction())
                {
                    var orderitem = Session.CreateCriteria<PurchaseOrderItem>().List<PurchaseOrderItem>();
                    
                    foreach (var item in orderitem)
                    {
                        var res = item.Name + item.QTY + item.TotalPrice;
                    }
                    var order = Session.CreateCriteria<PurchaseOrder>().List<PurchaseOrder>();

                    foreach (var item in order)
                    {
                        var res =item.Id +  item.Title;
                    }
                    
                        

                    Transaction.Commit();
                  
                }
            }
        }
    }
}
