using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Controllers.ApiControllers
{
    public class LikesController : ApiController
    {
        private readonly IPhotoService _photoService;

        public LikesController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        // GET: api/Likes/5
        public int Get(int id)
        {
            return _photoService.GetLikes(id);
        }

        // PUT: api/Likes/5
        public int Put(int id)
        {
            _photoService.Like(id);
            return _photoService.GetLikes(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources
                _photoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
