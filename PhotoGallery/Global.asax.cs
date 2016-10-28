using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using PhotoGallery.Controllers;
using PhotoGallery.Domain;
using PhotoGallery.Models;
using PhotoGallery.Services.DataObjects;
using PhotoGallery.App_Start;

namespace PhotoGallery
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperConfig.Configure();
        }

        //protected void Application_Error()
        //{
        //    Exception exception = Server.GetLastError();
        //    Response.Clear();

        //    string action = "General";

        //    HttpException httpException = exception as HttpException;

        //    if (httpException != null)
        //    {
        //        if (exception is HttpRequestValidationException)
        //        {

        //            action = "PotentiallyDangerousInput";
        //        }
        //        else
        //        {
        //            switch (httpException.GetHttpCode())
        //            {
        //                case 404:
        //                    action = "NotFound";
        //                    break;
        //            }
        //        }
        //        Server.ClearError();
        //    }

        //    Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, exception.Message));
        //}
    }
}
