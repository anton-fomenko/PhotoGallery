using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoGallery.Persistence;

namespace PhotoGallery.Controllers
{
    public class ImageController : Controller
    {
        PhotoGallery.Persistence.GalleryContext _db = new GalleryContext();
        public ActionResult Show(int id)
        {
            byte[] imageData = _db.Photos.Single(x => x.PhotoId == id).LargePhoto;
       
            return File(imageData, "image/jpg");
        }
    }
}