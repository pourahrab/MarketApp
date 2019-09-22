using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Market.Entities.ShouldMap;

namespace Market.Data.Mapping
{
    public class PurchaseOrderMap : IAutoMappingOverride<PurchaseOrder>
    {


        public void Override(AutoMapping<PurchaseOrder> mapping)
        {
            mapping.Id(o => o.Id).GeneratedBy.Assigned();
            mapping.Map(o => o.CreationDate);
            mapping.Map(o => o.Title);
            mapping.HasMany(o => o.PurchaseOrderItems).Cascade.AllDeleteOrphan();
        }
    }
}
