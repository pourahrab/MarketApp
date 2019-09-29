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
    public class ItemMap : IAutoMappingOverride<Item>
    {
        public void Override(AutoMapping<Item> mapping)
        {
            mapping.Id(i => i.Id).GeneratedBy.Assigned();
            mapping.Map(i => i.Name);
            mapping.Map(i => i.Unit);
            mapping.Map(i => i.Code);


        }
    }
}
