using NHibernate;
using System.Web.Mvc;

namespace GUT.Infra.DbConfiguration
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        public ISession Session { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!Session.Transaction.IsActive)
                return;

            var hasNoException = filterContext.Exception == null;
            var modelStateIsValid = filterContext.Controller.ViewData.ModelState.IsValid;

            if (hasNoException && modelStateIsValid)
            {
                Session.Transaction.Commit();
            }
            else
            {
                Session.Transaction.Rollback();
            }
        }
    }
}
