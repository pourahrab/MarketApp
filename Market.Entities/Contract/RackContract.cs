using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.ShouldMap;

namespace Market.Entities.Contract
{
    public class RackContract
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Location { get; set; }
        public virtual decimal Limit { get; set; }


        public Guid RackId { get; set; }
    }
}
