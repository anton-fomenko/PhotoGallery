using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Controllers.ApiControllers
{
    public class DislikesController : ApiController
    {
        private readonly IPhotoService _photoService;

        public DislikesController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        // GET: api/Dislikes/5
        public int Get(int id)
        {
            return _photoService.GetDislikes(id);
        }

        // PUT: api/Dislikes/5
        public int Put(int id)
        {
            _photoService.Dislike(id);
            return _photoService.GetDislikes(id);
        }
    }
}
