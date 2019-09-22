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
    public class RackMap : IAutoMappingOverride<Rack>
    {
        public void Override(AutoMapping<Rack> mapping)
        {
            mapping.Id(r => r.Id).GeneratedBy.Assigned();
            mapping.Map(r => r.Limit);
            mapping.Map(r => r.Name);
            mapping.Map(r => r.Location);

            mapping.References(r => r.Rack1).Cascade.All();
        }
    }
}
