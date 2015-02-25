using System;
using System.Linq;
using System.Web.Mvc;
using Petrobras.Security;

namespace GUT.Infra.Security
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        public string Roles { get; set; }

        private ISecurityContext _securityContext;
        public ISecurityContext SecurityContext
        {
            get { return _securityContext ?? (_securityContext = DependencyResolver.Current.GetService<ISecurityContext>()); }
            set { _securityContext = value; }
        }

        private string _accessDeniedMessage;
        public string AccessDeniedMessage
        {
            get { return _accessDeniedMessage ?? "Acesso negado ao recurso"; }
            set { _accessDeniedMessage = value; }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userRoles = GetRolesForCurrentUser();
            var roles = !String.IsNullOrEmpty(Roles) ? Roles.Split(',') : new string[]{};

            var isAuthorized = roles.Any(r => userRoles.Contains(r.Trim()));

            if (!isAuthorized)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                    AjaxAccessDeniedHandler(filterContext);
                else
                    NonAjaxAccessDeniedHandler(filterContext);
            }

            base.OnActionExecuting(filterContext);
        }

        private void NonAjaxAccessDeniedHandler(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
            filterContext.Result = new ViewResult { ViewName = "AcessoNegado" };
        }

        private void AjaxAccessDeniedHandler(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.Result = new ContentResult { Content = AccessDeniedMessage };
        }

        private string[] GetRolesForCurrentUser()
        {
            var chave = SecurityContext.CurrentLoggedUser.Login;
            return SecurityContext.UserRoleAuthorizationManager.FindUserRoles(chave).Select(r => r.Id).ToArray();
        }
    }
}
