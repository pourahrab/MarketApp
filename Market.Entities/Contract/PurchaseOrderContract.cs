using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.ShouldMap;

namespace Market.Entities.Contract
{
   public class PurchaseOrderContract
    {
        public PurchaseOrderContract()
        {
            PurchaseOrderItems=new List<PurchaseOrderItemContract>();
        }
        public virtual Guid Id { get; set; }
        public virtual DateTime CreationDate { get; set; }

        public virtual string Title { get; set; }

        public virtual decimal Code { get; set; }


        //public virtual ICollection<SaleOrderItem> SaleorderItems { get; set; }
        public virtual List<PurchaseOrderItemContract> PurchaseOrderItems { get; set; }
    }
}
