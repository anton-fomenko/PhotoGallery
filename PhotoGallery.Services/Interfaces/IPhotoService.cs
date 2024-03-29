﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;
using PhotoGallery.Services.DataObjects;

namespace PhotoGallery.Services.Interfaces
{
    public interface IPhotoService : IDisposable
    {
        List<Photo> GetPhotosOfTheUser(string userId);
        ListOfPhotosDto GetPhotoDtosOfTheUser(string userId);
        byte[] GetOriginalPhotoInBytesById(int photoId);
        byte[] GetThumbPhotoInBytesById(int photoId);
        Photo GetPhotoById(int id);
        void Modify(Photo photo);
        void DeletePhotos(List<int> photoIdList);
        void Remove(Photo photo);
        void AddPhoto(Photo model, Stream inputStream);
        byte[] GetMediumPhotoInBytesById(int id);
        ListOfPhotosDto Search(Photo photo, string userId);
        ListOfPhotosDto SearchByName(string photoName, string userId);
        int GetLikes(int photoId);
        void Like(int photoId, string userId);
        int GetDislikes(int photoId);
        void Dislike(int photoId, string userId);
        List<PhotoDto> PreparePhotoDtoList(string userId, List<Photo> photos);
    }
}
