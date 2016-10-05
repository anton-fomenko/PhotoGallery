using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Photo> GetPhotosOfTheUser(string userId)
        {
            return _unitOfWork.Photos.GetPhotosByUserId(userId).ToList();
        }

        public byte[] GetLargePhotoInBytesById(int photoId)
        {
            return _unitOfWork.Photos.GetLargePhotoById(photoId);
        }

        public Photo GetPhotoById(int id)
        {
            return _unitOfWork.Photos.Get(id);
        }

        public void AddPhoto(Photo model)
        {
            _unitOfWork.Photos.Add(model);
            _unitOfWork.Complete();
        }

        public void Modify(Photo photo)
        {
            Photo originalPhoto = _unitOfWork.Photos.Get(photo.PhotoId);
            originalPhoto.Description = photo.Description;
            _unitOfWork.Photos.Modify(originalPhoto);
            _unitOfWork.Complete();
        }

        public void Remove(Photo photo)
        {
            _unitOfWork.Photos.Remove(photo);
            _unitOfWork.Complete();
        }
    }
}
