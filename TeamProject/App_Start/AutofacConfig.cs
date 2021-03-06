﻿using Autofac;
using Autofac.Integration.Mvc;
using BLL.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamProject
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            builder.RegisterModule(new DataModule());
            var _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}