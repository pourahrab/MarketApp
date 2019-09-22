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
    public class SaleOrderItemMap : IAutoMappingOverride<SaleOrderItem>
    {
        public void Override(AutoMapping<SaleOrderItem> mapping)
        {
            mapping.Id(o => o.Id).GeneratedBy.Assigned();
            mapping.Map(o => o.Name);
            mapping.Map(o => o.QTY);
            mapping.Map(o => o.NetPrice);
            mapping.Map(o => o.TotalPrice);
            mapping.Map(o => o.UnitPrice);
            mapping.References(o => o.Item1);
            //     mapping.References(o => o.Rack1);

        }
    }
}
