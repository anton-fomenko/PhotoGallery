using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Persistence.Interfaces
{
    public interface IUserProfileRepository
    {
        void CreateUserProfile(string userId, string role);
    }
}
