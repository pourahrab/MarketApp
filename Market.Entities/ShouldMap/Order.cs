using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.ShouldMap
{
    public abstract class Order : BaseEntity
    {

        public Order()
        {
           

            SaleorderItems = new List<SaleOrderItem>();
            PurchaseOrderItems = new List<PurchaseOrderItem>();

        }



        public virtual DateTime CreationDate { get; set; }

        public virtual string Title { get; set; }


        public virtual ICollection<SaleOrderItem> SaleorderItems { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
