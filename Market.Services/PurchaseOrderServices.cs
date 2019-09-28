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
   public class PurchaseOrderServices 
    {
        private IPurchaseOrderRepository IPurchaseOrderRepository { get; set; }

        

        public void CreateAndDelete(PurchaseOrderContract purchaseOrderContract)
        {
            var PurchaseOrder = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);

            if (PurchaseOrder != null)
            {
                PurchaseOrder.CreationDate = purchaseOrderContract.CreationDate;
                PurchaseOrder.Title = purchaseOrderContract.Title;
                PurchaseOrder.PurchaseOrderItems = purchaseOrderContract.PurchaseOrderItems;

                IPurchaseOrderRepository.Update(PurchaseOrder);
            }
            else
            {
                PurchaseOrder.CreationDate = purchaseOrderContract.CreationDate;
                PurchaseOrder.Title = purchaseOrderContract.Title;
                PurchaseOrder.PurchaseOrderItems = purchaseOrderContract.PurchaseOrderItems;

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
