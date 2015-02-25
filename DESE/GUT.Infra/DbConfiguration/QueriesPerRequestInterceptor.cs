using System;
using System.Web;
using NHibernate;
using NHibernate.SqlCommand;

namespace GUT.Infra.DbConfiguration
{
    public class QueriesPerRequestInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            if (IsWebRequest() && IsSelectQuery(sql))
            {
                var numberOfQueries = (int)(HttpContext.Current.Items["nhibernate.numberOfQueries"] ?? 0);

                numberOfQueries++;

                HttpContext.Current.Items["nhibernate.numberOfQueries"] = numberOfQueries;

                if (numberOfQueries > 10)
                    throw new InvalidOperationException("Number of queries per request exceeded.");
            }

            return sql;
        }

        private bool IsWebRequest()
        {
            return HttpContext.Current != null;
        }

        private bool IsSelectQuery(SqlString sql)
        {
            return sql.StartsWithCaseInsensitive("select");
        }
    }
}
