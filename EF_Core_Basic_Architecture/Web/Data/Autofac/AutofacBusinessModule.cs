using Autofac;
using Azure;
using Castle.DynamicProxy;
using static System.Net.WebRequestMethods;
using System.Data;
using System.Security.Claims;
using Web.Data.Repository;
using Web.Data.Services;
using Autofac.Extras.DynamicProxy;

namespace Web.Data.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericViewRepository<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CrudRepository<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CrudViewRepository<>)).AsImplementedInterfaces().InstancePerLifetimeScope();

            #region Table
            builder.RegisterType<CrudService<Product>>().AsImplementedInterfaces().InstancePerLifetimeScope();
            #endregion

            #region View
            //builder.RegisterType<CrudViewService<vw_UrunlerList>>().AsImplementedInterfaces().InstancePerLifetimeScope();
            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).InstancePerLifetimeScope();
        }
    }
}
