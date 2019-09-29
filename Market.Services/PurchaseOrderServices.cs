using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contract;
using Market.Entities.Interfaces;
using Market.Entities.ShouldMap;

namespace Market.Services
{
    public class PurchaseOrderServices
    {
        private IPurchaseOrderRepository IPurchaseOrderRepository { get; set; }
        private IItemRepository iitemRepository { get; set; }
        private IRackRepository iRackRepository { get; set; }



        public void CreateAndDelete(PurchaseOrderContract purchaseOrderContract)
        {
            var PurchaseOrder = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);

            if (PurchaseOrder != null)
            {
                PurchaseOrder.CreationDate = DateTime.Now;
                PurchaseOrder.Title = purchaseOrderContract.Title;
                PurchaseOrder.Code = purchaseOrderContract.Code;
                
               for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
          
                {
                    var temp = purchaseOrderContract.PurchaseOrderItems[i];
                    if (PurchaseOrder.PurchaseOrderItems.Any(p => p.Id == temp.Id))
                    {
                        var Porderitem = PurchaseOrder.PurchaseOrderItems.FirstOrDefault(p => p.Id == temp.Id);

                        Porderitem.QTY = temp.QTY;
                        Porderitem.Name = temp.Name;
                        Porderitem.NetPrice = temp.NetPrice;
                        Porderitem.TotalPrice = temp.TotalPrice;
                        Porderitem.UnitPrice = temp.UnitPrice;
                        Porderitem.Item1 = iitemRepository.Get(temp.ItemId);
                        Porderitem.Rack1 = iRackRepository.Get(temp.RackId);
                        
                    }
                   
                    
                    else
                    {

                     var res = new PurchaseOrderItem();
                            res.QTY = temp.QTY;
                            res.Name = temp.Name;
                            res.NetPrice = temp.NetPrice;
                            res.TotalPrice = temp.TotalPrice;
                            res.UnitPrice = temp.UnitPrice;
                            res.Item1 = iitemRepository.Get(temp.ItemId);
                            res.Rack1 = iRackRepository.Get(temp.RackId);

                            PurchaseOrder.PurchaseOrderItems.Add(res);
                    }

                    
                }

                foreach (var item in PurchaseOrder.PurchaseOrderItems)
                {
                    if (PurchaseOrder.PurchaseOrderItems.Any(s => s.Id != item.Id))
                    {
                        
                       PurchaseOrder.PurchaseOrderItems.Remove(item);
                    }
                }
                IPurchaseOrderRepository.Update(PurchaseOrder);
            }
            else
            {
                PurchaseOrder.CreationDate = purchaseOrderContract.CreationDate;
                PurchaseOrder.Title = purchaseOrderContract.Title;
                PurchaseOrder.Code = purchaseOrderContract.Code;

                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
                {
                    var temp = purchaseOrderContract.PurchaseOrderItems[i];
                    if (PurchaseOrder.PurchaseOrderItems.Any(p => p.Id == temp.Id))
                    {
                        var Porderitem = PurchaseOrder.PurchaseOrderItems.FirstOrDefault(p => p.Id == temp.Id);

                        Porderitem.QTY = temp.QTY;
                        Porderitem.Name = temp.Name;
                        Porderitem.NetPrice = temp.NetPrice;
                        Porderitem.TotalPrice = temp.TotalPrice;
                        Porderitem.UnitPrice = temp.UnitPrice;
                        Porderitem.Item1 = iitemRepository.Get(temp.ItemId);
                        Porderitem.Rack1 = iRackRepository.Get(temp.RackId);
                    }
                }

                IPurchaseOrderRepository.Insert(PurchaseOrder);
            }
        }

        public void Delete(PurchaseOrderContract purchaseOrderContract)
        {
            var PurchaseOrderContract = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);

            IPurchaseOrderRepository.Delete(PurchaseOrderContract);
        }

    }
}
