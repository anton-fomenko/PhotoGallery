using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Persistence.Repositories;

namespace PhotoGallery.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GalleryContext _context;

        public IAlbumRepository Albums
        {
            get;
            private set;
        }

        public UnitOfWork()
        {
            _context = new GalleryContext();
            Albums = new AlbumRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
