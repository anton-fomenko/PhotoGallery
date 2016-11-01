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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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

        public ListOfPhotosDto GetPhotoDtosOfTheUser(string userId)
        {
            List<Photo> photos = _unitOfWork.Photos.GetPhotosByUserId(userId).ToList();
            List<PhotoDto> photoDtos = PreparePhotoDtoList(userId, photos);

            ListOfPhotosDto listOfPhotosDto = new ListOfPhotosDto
            {
                CanBeChanged = true,
                PhotoDtoList = photoDtos
            };

            return listOfPhotosDto;
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

        public ListOfPhotosDto Search(Photo photoModel, string userId)
        {
            List<Photo> photos = _unitOfWork.Photos.Search(photoModel, userId).ToList();
            List<PhotoDto> photoDtos = PreparePhotoDtoList(userId, photos);

            ListOfPhotosDto listOfPhotosDto = new ListOfPhotosDto
            {
                CanBeChanged = true,
                PhotoDtoList = photoDtos
            };
            return listOfPhotosDto;
        }

        public ListOfPhotosDto SearchByName(string photoName, string userId)
        {
            List<Photo> photos = _unitOfWork.Photos.SearchByName(photoName, userId).ToList();
            List<PhotoDto> photoDtos = PreparePhotoDtoList(userId, photos);

            ListOfPhotosDto listOfPhotosDto = new ListOfPhotosDto
            {
                CanBeChanged = true,
                PhotoDtoList = photoDtos
            };
            return listOfPhotosDto;
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
            originalPhoto.CreationDate = photo.CreationDate;

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

                Bitmap bitmapThumb = ResizeImage(img, 200, 200);
                using (Image newImg = bitmapThumb)
                {
                    photoBytesContent.ThumbPhoto = ImageToByteArray(newImg);
                }

                Bitmap bitmapOriginal = ResizeImage(img, img.Size.Width, img.Size.Height);
                using (Image newImg = bitmapOriginal)
                {
                    photoBytesContent.OriginalPhoto = ImageToByteArray(newImg);
                }

                Bitmap bitmapMedium = ResizeImage(img, 800, 800);
                using (Image newImg = bitmapMedium)
                {
                    photoBytesContent.MediumPhoto = ImageToByteArray(newImg);
                }

                model.PhotoBytesContent = photoBytesContent;

                // Save records to database
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

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public List<PhotoDto> PreparePhotoDtoList(string userId, List<Photo> photos)
        {
            List<PhotoDto> photoDtos = new List<PhotoDto>();
            foreach (Photo photo in photos)
            {
                PhotoDto photoDto = Mapper.Map<PhotoDto>(photo);

                UserProfile userProfile = _unitOfWork.UserProfiles.SingleOrDefault(u => u.UserIdentityId == userId);

                Vote vote = null;
                photoDto.CanVote = false;
                if (userProfile != null)
                {
                    vote = userProfile.Votes.SingleOrDefault(v => v.Photo.PhotoId == photo.PhotoId);
                    if (vote == null)
                    {
                        photoDto.CanVote = true;
                    }
                }

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

            _unitOfWork.Complete();
        }
    }
}
