using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;
using PhotoGallery.Services.DataObjects;

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
        AlbumDto GetAlbumByShortenedName(string albumName, string userId);
        bool IsAlbumExists(string name);
        void RemovePhotoFromAlbum(int photoId, int albumId);
        void DeletePhotosFromAlbum(DeletePhotosFromAlbumModel model);
    }
}
