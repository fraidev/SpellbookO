using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Spellbook.Infrastructure
{
    public static class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Data Source=.;Initial Catalog=SpellbookDB;Integrated Security=SSPI;")
                    .ShowSql())

                .Mappings(m => m.FluentMappings

                    .AddFromAssemblyOf<Program>()
                    .Conventions.Setup(c =>
                    {
                        c.Add(DefaultLazy.Never());  // Acabar com os virtual
                        //c.Add(DefaultCascade.All());
                    }))
                
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                    // .Create(true, true)
                )

                .BuildSessionFactory();
        }
    }
}