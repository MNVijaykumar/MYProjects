using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayerAPI.App_Start
{
    public class ComponentRegistry
    {
        public static void ConfigureComponents()
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType(typeof(CustomerService)).AsImplementedInterfaces();
            //builder.RegisterType(typeof(CustomerRepository)).AsImplementedInterfaces();
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}