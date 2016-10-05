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
        byte[] GetLargePhotoInBytesById(int photoId);
        Photo GetPhotoById(int id);
        void Modify(Photo photo);
        void Remove(Photo photo);
        void AddPhoto(Photo model, Stream inputStream, string fileName);
    }
}
