using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace GUT.Infra.DbConfiguration
{
    public class SessionFactoryBuilder
    {
        private Configuration configuration = new Configuration();
        private string connectionString;

        private Action<IDbIntegrationConfigurationProperties> SetSpecificDbOptions;

        public SessionFactoryBuilder WithConnectionString(string connectionString)
        {
            this.connectionString = connectionString;

            return this;
        }

        public SessionFactoryBuilder ForOracle()
        {
            SetSpecificDbOptions = db =>
            {
                db.Dialect<Oracle10gDialect>();
                db.Driver<OracleClientDriver>();
            };

            return this;
        }

        public ISessionFactory Build()
        {
            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionProvider<DriverConnectionProvider>();
                db.ConnectionString = connectionString;

                db.LogFormattedSql = true;

                if (SetSpecificDbOptions != null)
                    SetSpecificDbOptions(db);
            });

            configuration.SetInterceptor(new QueriesPerRequestInterceptor());
            configuration.AddMapping(CompileMappings());
            configuration.AddAssembly(System.Reflection.Assembly.Load(System.Configuration.ConfigurationManager.AppSettings["AssemblyMapeamento"]));

            var sessionFactory = configuration.BuildSessionFactory();

            return sessionFactory;
        }

        private static HbmMapping CompileMappings()
        {
            var mapper          = new ModelMapper();
            var aseemblyDominio = System.Reflection.Assembly.Load(System.Configuration.ConfigurationManager.AppSettings["AssemblyMapeamento"]);

            mapper.AddMappings(aseemblyDominio.GetExportedTypes());

            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
