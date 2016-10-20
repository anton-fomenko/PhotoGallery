using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoGallery.Domain;
using PhotoGallery.Models;

namespace PhotoGallery.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult CreateAlbum()
        {
            Album album = new Album();

            return View(album);
        }

        public ActionResult Index()
        {
            throw new Exception("test exception");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var photo = new Photo();
            
            return View(photo);
        } 
    }
}