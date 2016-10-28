using System.Data.Entity;
using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;

namespace PhotoGallery.Persistence
{
    public class GalleryContext : DbContext
    {
        public GalleryContext() :base("GalleryContext") { }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<PhotoBytesContent> PhotoBytesContents { get; set; }
    }
}
