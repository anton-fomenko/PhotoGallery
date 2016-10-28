using PhotoGallery.Models;
using PhotoGallery.Services.DataObjects;
using PhotoGallery.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoGallery.Controllers.ApiControllers
{
    public class AlbumApiController : ApiController
    {
        private readonly IAlbumService _albumService;
        public AlbumApiController() { }
        public AlbumApiController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public void Delete(DeletePhotosFromAlbumModel model)
        {
            _albumService.DeletePhotosFromAlbum(model);
        }
    }
}
