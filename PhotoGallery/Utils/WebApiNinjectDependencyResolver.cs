using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using DataArt.Web.Util;
using Ninject;

namespace PhotoGallery.Utils
{
    public class WebApiNinjectDependencyResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public WebApiNinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }

    }
}