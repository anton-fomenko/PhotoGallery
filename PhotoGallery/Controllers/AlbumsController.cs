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
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;
        public AlbumsController() {}
        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        // GET: Albums
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<Album> listOfAlbums = _albumService.GetAlbumsOfTheUser(userId); 
            List<AlbumViewModel> listOfAlbumsViewModels = Mapper.Map<List<AlbumViewModel>>(listOfAlbums);

            return View(listOfAlbumsViewModels);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album =_albumService.GetAlbum(id.Value);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Album album)
        {
            if (ModelState.IsValid)
            {
                album.UserId = User.Identity.GetUserId();

                if (User.IsInRole("FreeUser"))
                {
                    if (_albumService.GetAlbumsOfTheUser(album.UserId).Count >= 5)
                    {
                        ModelState.AddModelError("Error", "You have exceeded your maximimim number of 5 albums.");
                        return View();
                    }
                }

                _albumService.AddAlbum(album);
                return RedirectToAction("Index");
            }

            return View(album);
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
