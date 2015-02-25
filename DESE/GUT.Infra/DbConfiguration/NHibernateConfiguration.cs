using System.Configuration;
using NHibernate;

namespace GUT.Infra.DbConfiguration
{
    public class NHibernateConfiguration
    {
        public static ISessionFactory SessionFactory { get; set; }

        public static void BuildSessionFactory()
        {
            SessionFactory = new SessionFactoryBuilder()
                .WithConnectionString(ConfigurationManager.ConnectionStrings["GUT"].ConnectionString)
                .ForOracle()
                .Build();
        }
    }
}
