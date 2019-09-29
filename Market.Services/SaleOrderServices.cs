using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contract;
using Market.Entities.Interfaces;
using Market.Entities.ShouldMap;

namespace Market.Services
{
    public class SaleOrderServices
    {
        private ISaleOrderRepository ISaleOrderRepository { get; set; }
        private IItemRepository iitemRepository { get; set; }
        private IRackRepository iRackRepository { get; set; }
       
        //esmet ke doros nist
        public void CreateAndDelete(SaleOrderContract saleOrderContract) 
        {
            var SaleOrder = ISaleOrderRepository.Get(saleOrderContract.Id);

            if (SaleOrder != null)
            {
                SaleOrder.CreationDate = DateTime.Now;
                SaleOrder.Title = saleOrderContract.Title;
                SaleOrder.Code = saleOrderContract.Code;

                for (int i = 0; i < saleOrderContract.SaleorderItems.Count; i++)
                {
                    var temp = saleOrderContract.SaleorderItems[i];
                    if (SaleOrder.SaleorderItems.Any(p => p.Id == temp.Id))
                    {
                        var Sorderitem = SaleOrder.SaleorderItems.FirstOrDefault(p => p.Id == temp.Id);

                        Sorderitem.QTY = temp.QTY;
                        Sorderitem.Name = temp.Name;
                        Sorderitem.NetPrice = temp.NetPrice;
                        Sorderitem.TotalPrice = temp.TotalPrice;
                        Sorderitem.UnitPrice = temp.UnitPrice;
                        Sorderitem.Item1 = iitemRepository.Get(temp.ItemId);
                        Sorderitem.Rack1 = iRackRepository.Get(temp.RackId);

                    }


                    else
                    {
                        

                        var res = new SaleOrderItem();
                        res.QTY = temp.QTY;
                        res.Name = temp.Name;
                        res.NetPrice = temp.NetPrice;
                        res.TotalPrice = temp.TotalPrice;
                        res.UnitPrice = temp.UnitPrice;
                        res.Item1 = iitemRepository.Get(temp.ItemId);
                        res.Rack1 = iRackRepository.Get(temp.RackId);

                        SaleOrder.SaleorderItems.Add(res);
                    }


                }

                foreach (var item in SaleOrder.SaleorderItems)
                {
                    if (SaleOrder.SaleorderItems.Any(s => s.Id != item.Id))
                    {

                        SaleOrder.SaleorderItems.Remove(item);
                    }
                }
                ISaleOrderRepository.Update(SaleOrder);
            }
            else
            {
                SaleOrder.CreationDate = saleOrderContract.CreationDate;
                SaleOrder.Title = saleOrderContract.Title;
                SaleOrder.Code = saleOrderContract.Code;

                for (int i = 0; i < saleOrderContract.SaleorderItems.Count; i++)
                {
                    var temp = saleOrderContract.SaleorderItems[i];
                    if (SaleOrder.SaleorderItems.Any(p => p.Id == temp.Id))
                    {
                        var sorderitem = SaleOrder.SaleorderItems.FirstOrDefault(p => p.Id == temp.Id);

                        sorderitem.QTY = temp.QTY;
                        sorderitem.Name = temp.Name;
                        sorderitem.NetPrice = temp.NetPrice;
                        sorderitem.TotalPrice = temp.TotalPrice;
                        sorderitem.UnitPrice = temp.UnitPrice;
                        sorderitem.Item1 = iitemRepository.Get(temp.ItemId);
                        sorderitem.Rack1 = iRackRepository.Get(temp.RackId);
                    }
                }

                ISaleOrderRepository.Insert(SaleOrder);
            }
        }

        public void Delete(SaleOrderContract saleOrderContract)
        {
            var SaleOrderContract = ISaleOrderRepository.Get(saleOrderContract.Id);

            ISaleOrderRepository.Delete(SaleOrderContract); 
        }

    }
}
