using System;
using System.Web;
using GUT.Infra.DbConfiguration;
using NHibernate;

namespace GUT.Web.HttpModule
{
    public class SessionPerRequestModule : IHttpModule
    {
        public static ISession Session
        {
            get { return (ISession)HttpContext.Current.Items["nhibernate.current.session"]; }
            private set { HttpContext.Current.Items["nhibernate.current.session"] = value; }
        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += OnBeginRequest;
            application.EndRequest   += OnEndRequest;
        }

        private static void OnBeginRequest(object sender, EventArgs e)
        {
            var session = NHibernateConfiguration.SessionFactory.OpenSession();

            session.FlushMode = FlushMode.Commit;

            Session = session;
        }

        private static void OnEndRequest(object sender, EventArgs e)
        {
            var session = Session;

            if (session == null)
                return;

            session.Dispose();
        }

        public void Dispose()
        {
        }
    }
}