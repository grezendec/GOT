using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Petrobras.Security;

namespace GUT.Infra.Security
{
    public static class ResourceAuthorizerHtmlHelper
    {
        private static ISecurityContext _securityContext;
        public static ISecurityContext SecurityContext
        {
            get { return _securityContext ?? (_securityContext = DependencyResolver.Current.GetService<ISecurityContext>()); }
            set { _securityContext = value; }
        }

        public static bool IsAuthorized(this HtmlHelper helper, string[] roles)
        {
            var userRoles = GetRolesForCurrentUser();

            return roles.Any(userRoles.Contains);
        }

        private static IEnumerable<string> GetRolesForCurrentUser()
        {
            var chave = SecurityContext.CurrentLoggedUser.Login;
            return SecurityContext.UserRoleAuthorizationManager.FindUserRoles(chave).Select(r => r.Id).ToArray();
        }
    }
}