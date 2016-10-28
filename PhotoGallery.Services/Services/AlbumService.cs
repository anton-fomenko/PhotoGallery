using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Services.DataObjects;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public AlbumService(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        public List<Album> GetAlbumsOfTheUser(string userId)
        {
            return _unitOfWork.Albums.GetAlbumsByUserId(userId).ToList();
        }

        public Album GetAlbum(int albumId)
        {
            return _unitOfWork.Albums.Get(albumId);
        }

        public void AddAlbum(Album album, int photoId)
        {
            Photo photo = _unitOfWork.Photos.Get(photoId);
            album.MainPhoto = photo;
            _unitOfWork.Albums.Add(album);

            UserProfile userProfile = _unitOfWork.UserProfiles.SingleOrDefault(x => x.UserIdentityId == album.UserId);
            FreeUserProfile freeUserProfile = userProfile as FreeUserProfile;
            if (freeUserProfile != null)
            {
                freeUserProfile.FreeAlbumsCreated++;
            }
            _unitOfWork.Complete();
        }

        public void Modify(Album album)
        {
            Album originalAlbum = _unitOfWork.Albums.Get(album.Id);
            originalAlbum.Description = album.Description;
            originalAlbum.Name = album.Name;
            _unitOfWork.Albums.Modify(originalAlbum);
            _unitOfWork.Complete();
        }

        public void Remove(int albumId)
        {
            Album album = _unitOfWork.Albums.Get(albumId);

            // Remove the association with photo to avoid database errors during album deletion.
            album.MainPhoto = null;

            _unitOfWork.Albums.Remove(album);
            _unitOfWork.Complete();
        }

        public void AddPhotoToAlbum(int photoId, int albumId)
        {
            Album album = _unitOfWork.Albums.Get(albumId);
            Photo photo = _unitOfWork.Photos.Get(photoId);
            album.Photos.Add(photo);
            _unitOfWork.Complete();
        }

        public AlbumDto GetAlbumByShortenedName(string albumName, string userId)
        {
            albumName = albumName.Replace("-", " ");
            Album album = _unitOfWork.Albums.SingleOrDefault(x => x.Name == albumName);
            AlbumDto albumDto = Mapper.Map<AlbumDto>(album);

            List<PhotoDto> photoDtoList = _photoService.PreparePhotoDtoList(userId, album.Photos);
            albumDto.Photos = photoDtoList;
            albumDto.CanBeChanged = userId == albumDto.UserId;

            return albumDto;
        }

        public bool IsAlbumExists(string name)
        {
            IEnumerable<Album> albums = _unitOfWork.Albums.Find(a => a.Name == name);
            return albums.Any();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public void DeletePhotosFromAlbum(DeletePhotosFromAlbumModel model)
        {
            Album album = _unitOfWork.Albums.Get(model.AlbumId);
            album.Photos.RemoveAll(p => model.ArrayOfPhotoIds.Any(id => id == p.PhotoId));
            _unitOfWork.Complete();
        }
    }
}
