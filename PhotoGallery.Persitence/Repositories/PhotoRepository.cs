using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Modify(Photo photo)
        {
            _context.Entry(photo).State = EntityState.Modified;
        }
    }
}
