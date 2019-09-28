using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Contract
{
    public class OrderItemContract 
    {
        public Guid Id { get; set; }
        public virtual decimal QTY { get; set; }

        public virtual decimal NetPrice { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal TotalPrice { get; set; }

        public virtual decimal UnitPrice { get; set; }

        public Guid ItemId { get; set; }
        public Guid RackId { get; set; }
    }
}
