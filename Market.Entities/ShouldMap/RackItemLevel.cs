using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.ShouldMap
{
    public class RackItemLevel : BaseEntity
    {
        public RackItemLevel()
        {
           
        }

        public virtual decimal CurrentQty { get; set; }

        public virtual decimal InQty { get; set; }

        public virtual decimal OutQty { get; set; }


        public virtual Item Item1 { get; set; }

        public virtual Rack Rack1 { get; set; }
    }
}
