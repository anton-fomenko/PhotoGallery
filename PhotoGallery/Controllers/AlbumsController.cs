using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IPhotoService _photoService;
        private readonly IUserProfileService _userProfileService;
        public AlbumsController() { }
        public AlbumsController(IAlbumService albumService, IPhotoService photoService, IUserProfileService userProfileService)
        {
            _albumService = albumService;
            _photoService = photoService;
            _userProfileService = userProfileService;
        }

        // GET: Albums
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<Album> listOfAlbums = _albumService.GetAlbumsOfTheUser(userId);

            return View(listOfAlbums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(string albumName)
        {
            if (albumName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlbumDto album = _albumService.GetAlbumByShortenedName(albumName, User.Identity.GetUserId());

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            CreateAlbumViewModel createAlbumViewModel = new CreateAlbumViewModel
            {
                PhotosOfTheUser = _photoService.GetPhotosOfTheUser(userId)
            };
            return View(createAlbumViewModel);
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAlbumViewModel model)
        {
            string userId = User.Identity.GetUserId();
            model.PhotosOfTheUser = _photoService.GetPhotosOfTheUser(userId);

            if (ModelState.IsValid)
            {
                Album album = new Album()
                {
                    Description = model.Description,
                    Name = model.Name,
                    UserId = userId,
                };

                if (!_userProfileService.CanUserAddAlbum(album.UserId))
                {
                    ModelState.AddModelError("Error", "You have reached your maximum number of free albums");
                    return View(model);
                }

                if (_albumService.IsAlbumExists(album.Name))
                {
                    ModelState.AddModelError("Error", "Album with such name already exists");
                    return View(model);
                }

                _albumService.AddAlbum(album, model.SelectedMainPhotoId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = _albumService.GetAlbum(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Album album)
        {
            if (ModelState.IsValid)
            {
                _albumService.Modify(album);
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = _albumService.GetAlbum(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _albumService.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromAlbum(int id, int albumId)
        {
            string userId = User.Identity.GetUserId();
            _albumService.RemovePhotoFromAlbum(id, albumId);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources
                _albumService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
