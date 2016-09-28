using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Persistence;
using PhotoGallery.Persistence.Entities;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Services.Interfaces;
using PhotoGallery.Services.Domain;

namespace PhotoGallery.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Domain.Album> GetAlbumsOfTheUser(string userId)
        {
            return _unitOfWork.Albums.GetAlbumsByUserId(userId).ToList();
        }
    }
}
