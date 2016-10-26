using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Services.Interfaces
{
    public interface IUserProfileService
    {
        void CreateUserProfile(string userId, string role);
        bool CanUserAddPhoto(string userId);
        bool CanUserAddAlbum(string userId);
    }
}
