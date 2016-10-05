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

            var model = new Photo
            {
                Description = photo.Description,
                UserId = User.Identity.GetUserId()
            };

            _photoService.AddPhoto(model, photo.File.InputStream, photo.File.FileName);

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
                // Release managed resources
                _photoService.Dispose();
            }
        }
    }
}
