using System.Data.Entity;
using PhotoGallery.Domain;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                    .HasRequired<Photo>(s => s.MainPhoto)
                    .WithMany(s => s.MainPhotoAlbums)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photo>()
                         .HasMany<Album>(s => s.Albums)
                         .WithMany(c => c.Photos);
        }
    }
}
