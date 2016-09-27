using System.Data.Entity;
using PhotoGallery.Domain;

namespace PhotoGallery.Persistence
{
    public class GalleryContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
