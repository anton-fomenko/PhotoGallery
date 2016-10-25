using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using PhotoGallery.Persistence;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Services.Interfaces;
using PhotoGallery.Services.Services;

namespace PhotoGallery.DependencyResolver
{
    public class DependencyResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IAlbumService>().To<AlbumService>();
            Bind<IPhotoService>().To<PhotoService>();
            Bind<IUserProfileService>().To<UserProfileService>();
        }
    }
}
