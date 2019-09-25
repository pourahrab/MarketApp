using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using Market.Entities.ShouldMap;
using NHibernate.Type;

namespace Market.Data.Configuration
{
    public class NhibernateConfig : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
           // return type.Namespace == "Market.Entities.ShouldMap";
            //return type.Namespace.EndsWith("Market.Entities.ShouldMap");
           // return type.Namespace == typeof(Market.Entities.ShouldMap.BaseEntity).Namespace;
            //return type.Namespace == typeof(BaseEntity).Namespace;


           return typeof(BaseEntity).IsAssignableFrom(type) && !type.IsAbstract;

           
        }
    }
}
