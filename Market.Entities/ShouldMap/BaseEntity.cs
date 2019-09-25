using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.ShouldMap
{
    public  class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();

        }


        public virtual Guid Id { get; set; }
    }
}
