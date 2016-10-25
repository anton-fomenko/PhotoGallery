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
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        private readonly GalleryContext _context;
        public UserProfileRepository(GalleryContext context) : base(context)
        {
            _context = context;
        }

        public void CreateUserProfile(string userId, string role)
        {
            UserProfile userProfile;

            switch (role)
            {
                case "FreeUser":
                    userProfile = new FreeUserProfile() { UserIdentityId = userId};
                    break;
                case "PaidUser":
                    userProfile = new PaidUserProfile() {UserIdentityId = userId};
                    break;
                default:
                    throw new ArgumentException("The role for User Profile was not provided.");
            }

            _context.UserProfiles.Add(userProfile);
        }
    }
}
