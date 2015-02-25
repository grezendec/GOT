using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GUT.Core.Repositories;
using GUT.Infra.Specifications;
using GUT.Web.HttpModule;
using NHibernate;
using Petrobras.Security;
using Petrobras.Security.Management.Access;
using Petrobras.Security.Management.Authorization;
using Petrobras.Security.Management.Basic;
using Petrobras.Security.Manager.Inactivation;

namespace GUT.Web
{
    public class DependencyResolverConfig
    {
        public static void SetDependencyResolver()
        {
            var builder = new ContainerBuilder();
            var assembly = typeof(DependencyResolverConfig).Assembly;

            builder.RegisterControllers(assembly);
            builder.RegisterFilterProvider();
            
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Namespace.EndsWith("GUT.Core.Repositories") && t.IsInterface == false)
                .AsImplementedInterfaces()
                .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableTo<ISpecification>())
                .AsSelf()
                .InstancePerHttpRequest();

            builder.Register(i => SessionPerRequestModule.Session).As<ISession>();

            builder.RegisterGeneric(typeof(Repositorio<>)).As(typeof(IRepositorio<>)).InstancePerHttpRequest();

            builder.Register(r => ISecurityContext.GetContext()).As<ISecurityContext>();
            builder.Register(r => ISecurityContext.GetContext().UserManager).As<IUserManager>();
            builder.Register(r => ISecurityContext.GetContext().RoleManager).As<IRoleManager>();
            builder.Register(r => ISecurityContext.GetContext().UserRoleAuthorizationManager).As<IUserRoleAuthorizationManager>();
            builder.Register(r => ISecurityContext.GetContext().UserInactivationManager).As<IUserInactivationManager>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}