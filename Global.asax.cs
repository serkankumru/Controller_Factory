using Autofac;
using Autofac.Integration.Mvc;
using DAL;
using DAL.Repository;
using News.ControllerFactory;
using News.MyModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace News
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
            ModelBinders.Binders.Add(typeof(NewsT),new NewModelBinder());
            
            
            MyControllerFactory myController = new MyControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(myController);


            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<EditorRepository>().As<EditorRepository>();
            builder.RegisterType<NewsRepository>().As<NewsRepository>();
            builder.RegisterType<ImageRepository>().As<ImageRepository>();
            builder.RegisterType<CategoryRepository>().As<CategoryRepository>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
