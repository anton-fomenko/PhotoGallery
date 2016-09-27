using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoGallery.Domain;
using PhotoGallery.Models;
using PhotoGallery.Persistence;

namespace PhotoGallery.Controllers
{
    public class HomeController : Controller
    {
        private GalleryContext _db = new GalleryContext();

        [HttpGet]
        public ActionResult CreateAlbum()
        {
            Album album = new Album();

            return View(album);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImageGallery(string filter = null, int page = 1, int pageSize = 20)
        {
            PagedList<Photo> records = new PagedList<Photo>();
            ViewBag.filter = filter;

            records.Content = _db.Photos
                .Where(x => filter == null || x.Description.Contains(filter))
                .OrderByDescending(x => x.PhotoId)
                .Skip((page - 1)*pageSize)
                .Take(pageSize)
                .ToList();

            records.TotalRecords = _db.Photos.Count(x => filter == null || x.Description.Contains(filter));
            records.PageSize = pageSize;

            return View(records);
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

        public Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
                finalSize = imageSize; // image is already small size

            return finalSize;
        }

        private void SaveToFolder(Image img, string fileName, string extension, Size newSize, string pathToSave)
        {
            // Get new resolution
            Size imgSize = NewImageSize(img.Size, newSize);

            using (System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
            {
                ImageToByteArray(img);
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        [HttpPost]
        public ActionResult Create(Photo photo, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
                return View(photo);
            if (!files.Any() || files.FirstOrDefault() == null)
            {
                ViewBag.error = "Please choose a file";
                return View(photo);
            }

            var model = new Photo();
            foreach (var file in files)
            {
                if (file.ContentLength == 0) continue;

                model.Description = photo.Description;
                var fileName = Guid.NewGuid().ToString();
                var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

                using (var img = System.Drawing.Image.FromStream(file.InputStream))
                {
                    // Save thumbnail size image, 100 x 100
                    // Get new resolution
                    Size imgSize = NewImageSize(img.Size, new Size(100, 100));

                    using (System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
                    {
                        model.ThumbPhoto = ImageToByteArray(newImg);
                    }

                    // Save large size image, 800 x 800
                    // Get new resolution
                    Size bigOmgSize = NewImageSize(img.Size, new Size(800, 800));

                    using (System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
                    {
                        model.LargePhoto= ImageToByteArray(newImg);
                    }
                }

                // Save record to database
                model.CreatedOn = DateTime.Now;
                _db.Photos.Add(model);
                _db.SaveChanges();
            }

            return RedirectPermanent("/home");
        }

    }
}