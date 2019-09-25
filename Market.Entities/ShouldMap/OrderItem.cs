using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.ShouldMap
{
    public abstract class OrderItem : BaseEntity
    {

        public OrderItem()
        {
           
        }

       

        public virtual decimal QTY { get; set; }

        public virtual decimal NetPrice { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal TotalPrice { get; set; }

        public virtual decimal UnitPrice { get; set; }

        public virtual Item Item1 { get; set; }

         public virtual Rack Rack1 { get; set; }



    }
}
