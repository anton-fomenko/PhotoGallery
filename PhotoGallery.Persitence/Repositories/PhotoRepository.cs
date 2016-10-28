using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;

namespace PhotoGallery.Persistence.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        private readonly GalleryContext _context;

        public PhotoRepository(GalleryContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Photo> GetPhotosByUserId(string userId)
        {
            return _context.Photos.Where(x => x.UserId == userId);

        }

        public void RemoveIncludingBytesContent(Photo photo)
        {
            Photo realPhotoEntity = _context.Photos.Single(x => x.PhotoId == photo.PhotoId);

            PhotoBytesContent photoBytesContent = realPhotoEntity.PhotoBytesContent;
            _context.PhotoBytesContents.Remove(photoBytesContent);


            List<Vote> votes = realPhotoEntity.Votes;
            _context.Votes.RemoveRange(votes);

            _context.Photos.Remove(realPhotoEntity);
        }

        public void Modify(Photo photo)
        {
            _context.Entry(photo).State = EntityState.Modified;
        }

        public byte[] GetOriginalPhoto(int photoId)
        {
            return _context.Photos.Where(x => x.PhotoId == photoId).Select(x => x.PhotoBytesContent.OriginalPhoto).Single();
        }

        public byte[] GetMediumPhoto(int photoId)
        {
            return _context.Photos.Where(x => x.PhotoId == photoId).Select(x => x.PhotoBytesContent.MediumPhoto).Single();
        }

        public byte[] GetThumbPhoto(int photoId)
        {
            return _context.Photos.Where(x => x.PhotoId == photoId).Select(x => x.PhotoBytesContent.ThumbPhoto).Single();
        }

        public IEnumerable<Photo> Search(Photo photoModel, string userId)
        {
            IQueryable<Photo> query = _context.Photos;

            if (photoModel.Name != null)
                query = query.Where(s => s.Name == photoModel.Name);
            if (photoModel.Description != null)
                query = query.Where(s => s.Description == photoModel.Description);
            if (photoModel.Iso != null)
                query = query.Where(s => s.Iso == photoModel.Iso);
            if (photoModel.Aperture != null)
                query = query.Where(s => s.Aperture == photoModel.Aperture);
            if (photoModel.CameraModel != null)
                query = query.Where(s => s.CameraModel == photoModel.CameraModel);
            if (photoModel.CreationDate != null)
                query = query.Where(s => s.CreationDate == photoModel.CreationDate);
            if (photoModel.Flash != null)
                query = query.Where(s => s.Flash == photoModel.Flash);

            return query;
        }

        public IEnumerable<Photo> SearchByName(string photoName, string userId)
        {
            return _context.Database.SqlQuery<Photo>("exec spGetPhotosByName @Name, @UserId",
                new SqlParameter("@Name", photoName),
                new SqlParameter("@UserId", userId));
        }
    }
}
