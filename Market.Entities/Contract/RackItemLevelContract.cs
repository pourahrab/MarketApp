using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.ShouldMap;

namespace Market.Entities.Contract
{
    public class RackItemLevelContract
    {
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }
        public Guid RackId { get; set; }


        public virtual decimal CurrentQty { get; set; }

        public virtual decimal InQty { get; set; }

        public virtual decimal OutQty { get; set; }


    

    }
}
