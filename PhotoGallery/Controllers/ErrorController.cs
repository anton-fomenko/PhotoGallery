using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult PotentiallyDangerousInput()
        {
            return View();
        }

        public ActionResult General()
        {
            return View("Error");
        }
    }
}