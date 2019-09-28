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
       

        public void CreateAndDelete(SaleOrderContract saleOrderContract) 
        {
            var SaleOrderContract = ISaleOrderRepository.Get(saleOrderContract.Id);

            if (SaleOrderContract != null)
            {
                SaleOrderContract.CreationDate = saleOrderContract.CreationDate;
                SaleOrderContract.Title = saleOrderContract.Title;
                SaleOrderContract.SaleorderItems = saleOrderContract.SaleorderItems;

                ISaleOrderRepository.Update(SaleOrderContract);
            }
            else
            {
                SaleOrder saleorder = new SaleOrder();
                saleorder.CreationDate = saleOrderContract.CreationDate;
                saleorder.Title = saleOrderContract.Title;
                saleorder.SaleorderItems = saleOrderContract.SaleorderItems;

                ISaleOrderRepository.Insert(saleorder);
            }
        }

        public void Delete(SaleOrderContract saleOrderContract)
        {
            var SaleOrderContract = ISaleOrderRepository.Get(saleOrderContract.Id);

            ISaleOrderRepository.Delete(SaleOrderContract); 
        }

    }
}
