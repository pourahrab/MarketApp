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
    public class RackLevelMap : IAutoMappingOverride<RackItemLevel>
    {
        public void Override(AutoMapping<RackItemLevel> mapping)
        {
            mapping.Id(m => m.Id).GeneratedBy.Assigned();
            mapping.Map(m => m.CurrentQty);
            mapping.Map(m => m.InQty);
            mapping.Map(m => m.OutQty);
            mapping.References(m => m.Item1).Cascade.All();
            mapping.References(m => m.Rack1).Cascade.All();
        }
    }
}
