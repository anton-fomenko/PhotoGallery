using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoGallery.Models;

namespace PhotoGallery.App_Start
{
    public class PhotoGalleryIdentityDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
    }
}