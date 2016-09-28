using System.Collections.Generic;
using System.Linq;
using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Album> GetAlbumsOfTheUser(string userId)
        {
            return _unitOfWork.Albums.GetAlbumsByUserId(userId).ToList();
        }
    }
}
