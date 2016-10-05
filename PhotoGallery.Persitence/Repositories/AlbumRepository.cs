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
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly GalleryContext _context;
        public AlbumRepository(GalleryContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Album> GetAlbumsByUserId(string userId)
        {
            return _context.Albums.Where(x => x.UserId == userId);
        }

        public void Modify(Album album)
        {
            _context.Entry(album).State = EntityState.Modified;
        }
    }
}
