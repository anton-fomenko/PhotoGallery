using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;
using PhotoGallery.Persistence;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly GalleryContext _db = new GalleryContext();

        //public AlbumService(IAlbumService albumService)
        //{
        //    _albumService = albumService;
        //}

        public List<Album> GetAlbumsOfTheUser(string userId)
        {
            return _db.Albums.Where(x => x.UserId == userId).ToList();
        }
    }
}
