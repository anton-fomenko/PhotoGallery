﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PhotoGallery.Domain;
using PhotoGallery.Models;
using PhotoGallery.Services.DataObjects;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Controllers
{
    [Authorize]
    public class PhotosController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IAlbumService _albumService;
        private readonly IUserProfileService _userProfileService;

        public PhotosController() { }
        public PhotosController(IPhotoService photoService, IAlbumService albumService, IUserProfileService userProfileService)
        {
            _photoService = photoService;
            _albumService = albumService;
            _userProfileService = userProfileService;
        }

        // GET: Photos
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();

            return View(_photoService.GetPhotoDtosOfTheUser(userId));
        }

        [AllowAnonymous]
        public ActionResult ShowOriginalPhoto(int id)
        {
            byte[] imageData = _photoService.GetOriginalPhotoInBytesById(id);
            return File(imageData, "image/jpg");
        }

        [AllowAnonymous]
        public ActionResult ShowThumbPhoto(int id)
        {
            byte[] imageData = _photoService.GetThumbPhotoInBytesById(id);
            return File(imageData, "image/jpg");
        }

        [AllowAnonymous]
        public ActionResult ShowMediumPhoto(int id)
        {
            byte[] imageData = _photoService.GetMediumPhotoInBytesById(id);
            return File(imageData, "image/jpg");
        }

        [AllowAnonymous]
        public ActionResult PhotoModalDialog(int? id)
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
            return PartialView(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreatePhotoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.File == null)
            {
                ViewBag.Error = "Please choose a file";
                return View(model);
            }

            if (!_userProfileService.CanUserAddPhoto(User.Identity.GetUserId()))
            {
                ModelState.AddModelError("Error", "You have reached your maximum number of free photos");
                return View(model);
            }

            Photo photo = Mapper.Map<Photo>(model);
            photo.UserId = User.Identity.GetUserId();

            _photoService.AddPhoto(photo, model.File.InputStream);

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
        public ActionResult Edit(
            [Bind(Include = "PhotoId,Description,Name,Location,CameraModel,FocalLengthOfLens,Aperture,ShutterSpeed,Iso,Flash")]
            Photo photo)
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
            try
            {
                _photoService.Remove(photo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("FailedToDeletePhoto");
            }
        }

        [HttpPost]
        public ActionResult DeleteSelected(List<int> selectedItems)
        {
            try
            {
                _photoService.DeletePhotos(selectedItems);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("FailedToDeletePhoto");
            }
        }

        public ActionResult AddToAlbum(int id)
        {
            string userId = User.Identity.GetUserId();
            Photo photo = _photoService.GetPhotoById(id);
            List<Album> albums = _albumService.GetAlbumsOfTheUser(userId);
            AddToItemViewModel model = new AddToItemViewModel() { Photo = photo, Albums = albums };
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddToAlbum(int photoId, int albumId)
        {
            _albumService.AddPhotoToAlbum(photoId, albumId);
            return RedirectToAction("Index");
        }

        public ActionResult Search(string name)
        {
            string userId = User.Identity.GetUserId();
            ListOfPhotosDto photos = _photoService.SearchByName(name, userId);
            return View("Index", photos);
        }

        [HttpGet]
        public ActionResult AdvancedSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdvancedSearch(Photo searchModel)
        {
            string userId = User.Identity.GetUserId();
            ListOfPhotosDto photos = _photoService.Search(searchModel, userId);
            return View("Index", photos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources
                _photoService.Dispose();
                _albumService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
