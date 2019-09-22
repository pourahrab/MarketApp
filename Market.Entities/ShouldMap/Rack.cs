using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.ShouldMap
{
    public class Rack
    {
        public Rack()
        {
            Id = Guid.NewGuid();




        }

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Location { get; set; }
        public virtual decimal Limit { get; set; }


        public virtual Rack Rack1 { get; set; }



    } 
}
