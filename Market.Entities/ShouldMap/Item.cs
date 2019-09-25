using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Utility;

namespace Market.Entities.ShouldMap
{
    public class Item : BaseEntity
    {
        public Item()
        {
            

        }


        

        public virtual string Name { get; set; }

        public virtual UnitType Unit { get; set; }


    }
}
