using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PhotoGallery.Domain;
using PhotoGallery.Models;
using PhotoGallery.Persistence;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Controllers
{
    [Authorize]
    public class PhotosController : Controller
    {
        private GalleryContext db = new GalleryContext();
        private readonly IPhotoService _photoService;

        public PhotosController() { }
        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        // GET: Photos
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            return View(_photoService.GetPhotosOfTheUser(userId));
        }

        public ActionResult Show(int id)
        {
            byte[] imageData = _photoService.GetLargePhotoInBytesById(id);
            return File(imageData, "image/jpg");
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Photo photo = _photoService.GetPhotoById(id.Value);

            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreatePhotoViewModel photo)
        {
            if (!ModelState.IsValid)
                return View(photo);
            if (photo.File == null)
            {
                ViewBag.error = "Please choose a file";
                return View(photo);
            }

            var model = new Photo();
            if (photo.File.ContentLength != 0)
            {
                model.Description = photo.Description;
                model.UserId = User.Identity.GetUserId();
                var fileName = Guid.NewGuid().ToString();
                var extension = System.IO.Path.GetExtension(photo.File.FileName).ToLower();

                using (var img = System.Drawing.Image.FromStream(photo.File.InputStream))
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
                        model.LargePhoto = ImageToByteArray(newImg);
                    }
                }

                // Save record to database
                model.CreatedOn = DateTime.Now;

                _photoService.AddPhoto(model);
            }

            return RedirectToAction("Index");
        }


        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = _photoService.GetPhotoById(id.Value);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoId,Description,CreatedOn,ThumbPhoto,LargePhoto")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                _photoService.Modify(photo);
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = _photoService.GetPhotoById(id.Value);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = _photoService.GetPhotoById(id);
            _photoService.Remove(photo);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private Size NewImageSize(Size imageSize, Size newSize)
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

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}
