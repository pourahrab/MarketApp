using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Market.Data.Mapping;
using Market.Entities.ShouldMap;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Market.Data.Configuration
{
    public class NhibernateLayer
    {
        private static ISessionFactory _SessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_SessionFactory == null)
                {
                    CreateSessionFactory();
                }

                return _SessionFactory;
            }
        }

        private static void CreateSessionFactory()
        {

            var cfg = new NhibernateConfig();

            _SessionFactory = Fluently.Configure().Database
                    (MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=.;Initial Catalog=NHibernateTest;Persist Security Info=True;User ID=sa;Password=sa123").ShowSql())
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Rack>(cfg)
                    .UseOverridesFromAssemblyOf<RackMap>()))

                .ExposeConfiguration(conf =>
                {
                    new SchemaUpdate(conf).Execute(false, true);

                    new SchemaExport(conf).Create(false, false);
                })
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();


        }
    }
}
