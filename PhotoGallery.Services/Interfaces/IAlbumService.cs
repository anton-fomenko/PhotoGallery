using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;

namespace PhotoGallery.Services.Interfaces
{
    public interface IAlbumService : IDisposable
    {
        List<Album> GetAlbumsOfTheUser(string userId);
        Album GetAlbum(int albumId);
        void AddAlbum(Album album, int photoId);
        void Modify(Album album);
        void Remove(int albumId);
        void AddPhotoToAlbum(int photoId, int albumId);
        Album GetAlbumByShortenedName(string albumName);
        bool IsAlbumExists(string name);
        void RemovePhotoFromAlbum(int photoId, int albumId);
    }
}
