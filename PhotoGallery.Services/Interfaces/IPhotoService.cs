using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;

namespace PhotoGallery.Services.Interfaces
{
    public interface IPhotoService : IDisposable
    {
        List<Photo> GetPhotosOfTheUser(string userId);
        byte[] GetOriginalPhotoInBytesById(int photoId);
        byte[] GetThumbPhotoInBytesById(int photoId);
        Photo GetPhotoById(int id);
        void Modify(Photo photo);
        void Remove(Photo photo);
        void AddPhoto(Photo model, Stream inputStream);
        byte[] GetMediumPhotoInBytesById(int id);
        List<Photo> Search(Photo photo, string userId);
        List<Photo> SearchByName(string photoName, string userId);
        int GetLikes(int photoId);
        void Like(int photoId, string userId);
        int GetDislikes(int photoId);
        void Dislike(int photoId);
    }
}
