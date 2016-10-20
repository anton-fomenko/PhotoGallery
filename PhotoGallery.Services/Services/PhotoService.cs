using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public byte[] GetOriginalPhotoInBytesById(int photoId)
        {
            return _unitOfWork.Photos.GetOriginalPhoto(photoId);
        }

        public byte[] GetThumbPhotoInBytesById(int photoId)
        {
            return _unitOfWork.Photos.GetThumbPhoto(photoId);
        }

        public byte[] GetMediumPhotoInBytesById(int photoId)
        {
            return _unitOfWork.Photos.GetMediumPhoto(photoId);
        }

        public Photo GetPhotoById(int photoId)
        {
            return _unitOfWork.Photos.Get(photoId);
        }

        public void Modify(Photo photo)
        {
            Photo originalPhoto = _unitOfWork.Photos.Get(photo.PhotoId);

            originalPhoto.Description = photo.Description;
            originalPhoto.Name = photo.Name;
            originalPhoto.Aperture = photo.Aperture;
            originalPhoto.CameraModel = photo.CameraModel;
            originalPhoto.Flash = photo.Flash;
            originalPhoto.FocalLengthOfLens = photo.FocalLengthOfLens;
            originalPhoto.Iso = photo.Iso;
            originalPhoto.ShutterSpeed = photo.ShutterSpeed;
            originalPhoto.Location = photo.Location;
            originalPhoto.CreatedOn = photo.CreatedOn;

            _unitOfWork.Photos.Modify(originalPhoto);
            _unitOfWork.Complete();
        }

        public void Remove(Photo photo)
        {
            _unitOfWork.Photos.Remove(photo);
            _unitOfWork.Complete();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public void AddPhoto(Photo model, Stream inputStream)
        {
            using (var img = Image.FromStream(inputStream))
            {
                PhotoBytesContent photoBytesContent = new PhotoBytesContent();

                // Save thumbnail size image, 100 x 100
                Size imgSize = NewImageSize(img.Size, new Size(100, 100));
                using (Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
                {
                    photoBytesContent.ThumbPhoto = ImageToByteArray(newImg);
                }

                // Save original size image
                using (Image newImg = new Bitmap(img, img.Size.Width, img.Size.Height))
                {
                    photoBytesContent.OriginalPhoto = ImageToByteArray(newImg);
                }

                // Save medium size image, 500 x 500
                Size mediumSize = NewImageSize(img.Size, new Size(800, 800));
                using (Image newImg = new Bitmap(img, mediumSize.Width, mediumSize.Height))
                {
                    photoBytesContent.MediumPhoto = ImageToByteArray(newImg);
                }

                model.PhotoBytesContent = photoBytesContent;

                // Save record to database
                model.CreatedOn = DateTime.Now;

                _unitOfWork.Photos.Add(model);
                _unitOfWork.Complete();
            }
        }

        private Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
                finalSize = imageSize; // image is already small size

            return finalSize;
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}
