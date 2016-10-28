using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Services.DataObjects;
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

        public List<PhotoDto> GetPhotoDtosOfTheUser(string userId)
        {
            List<Photo> photos = _unitOfWork.Photos.GetPhotosByUserId(userId).ToList();
            List<PhotoDto> photoDtos = PreparePhotoDtoList(userId, photos);
            return photoDtos;
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

        public List<PhotoDto> Search(Photo photoModel, string userId)
        {
            List<Photo> photos = _unitOfWork.Photos.Search(photoModel, userId).ToList();
            List<PhotoDto> photoDtos = PreparePhotoDtoList(userId, photos);
            return photoDtos;
        }

        public List<PhotoDto> SearchByName(string photoName, string userId)
        {
            List<Photo> photos = _unitOfWork.Photos.SearchByName(photoName, userId).ToList();
            List<PhotoDto> photoDtos = PreparePhotoDtoList(userId, photos);
            return photoDtos;
        }

        public int GetLikes(int photoId)
        {
            return _unitOfWork.Photos.Get(photoId).Likes;
        }

        public void Like(int photoId, string userId)
        {
            Photo photo = _unitOfWork.Photos.Get(photoId);
            photo.Likes++;

            Vote vote = new Vote()
            {
                Liked = true,
                Photo = photo
            };

            _unitOfWork.UserProfiles.SingleOrDefault(u => u.UserIdentityId == userId).Votes.Add(vote);
            _unitOfWork.Complete();
        }

        public int GetDislikes(int photoId)
        {
            return _unitOfWork.Photos.Get(photoId).Dislikes;
        }

        public void Dislike(int photoId, string userId)
        {
            Photo photo = _unitOfWork.Photos.Get(photoId);
            photo.Dislikes++;

            Vote vote = new Vote()
            {
                Liked = false,
                Photo = photo
            };

            _unitOfWork.UserProfiles.SingleOrDefault(u => u.UserIdentityId == userId).Votes.Add(vote);
            _unitOfWork.Complete();
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
            _unitOfWork.Photos.RemoveIncludingBytesContent(photo);
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

                Size imgSize = NewImageSize(img.Size, new Size(200, 200));
                using (Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
                {
                    photoBytesContent.ThumbPhoto = ImageToByteArray(newImg);
                }

                using (Image newImg = new Bitmap(img, img.Size.Width, img.Size.Height))
                {
                    photoBytesContent.OriginalPhoto = ImageToByteArray(newImg);
                }

                Size mediumSize = NewImageSize(img.Size, new Size(800, 800));
                using (Image newImg = new Bitmap(img, mediumSize.Width, mediumSize.Height))
                {
                    photoBytesContent.MediumPhoto = ImageToByteArray(newImg);
                }

                model.PhotoBytesContent = photoBytesContent;

                // Save records to database
                model.CreatedOn = DateTime.Now;

                _unitOfWork.Photos.Add(model);
                UserProfile userProfile = _unitOfWork.UserProfiles.SingleOrDefault(x => x.UserIdentityId == model.UserId);
                FreeUserProfile freeUserProfile = userProfile as FreeUserProfile;
                if (freeUserProfile != null)
                {
                    freeUserProfile.FreePhotosUploaded++;
                }

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

        private List<PhotoDto> PreparePhotoDtoList(string userId, List<Photo> photos)
        {
            List<PhotoDto> photoDtos = new List<PhotoDto>();
            foreach (Photo photo in photos)
            {
                PhotoDto photoDto = Mapper.Map<PhotoDto>(photo);

                UserProfile userProfile = _unitOfWork.UserProfiles.SingleOrDefault(u => u.UserIdentityId == userId);
                Vote vote = userProfile.Votes.SingleOrDefault(v => v.Photo.PhotoId == photo.PhotoId);
                photoDto.CanVote = vote == null;

                if (!photoDto.CanVote)
                {
                    if (vote != null) photoDto.Liked = vote.Liked;
                }

                photoDtos.Add(photoDto);
            }
            return photoDtos;
        }

        public void DeletePhotos(List<int> photoIdList)
        {
            foreach (int photoId in photoIdList)
            {
                Photo photo = _unitOfWork.Photos.Get(photoId);
                Remove(photo);
            }

            //List<Photo> photos = _unitOfWork.Photos.Find(p => photoIdList.Any(id => id == p.PhotoId)).ToList();
            //_unitOfWork.Photos.RemoveRange(photos);
            _unitOfWork.Complete();
        }
    }
}
