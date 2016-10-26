using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Services.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateUserProfile(string userId, string role)
        {
            _unitOfWork.UserProfiles.CreateUserProfile(userId, role);
            _unitOfWork.Complete();
        }

        public bool CanUserAddPhoto(string userId)
        {
            FreeUserProfile userProfile = _unitOfWork.UserProfiles.SingleOrDefault(x => x.UserIdentityId == userId) as FreeUserProfile;
            int freePhotosLimit = Convert.ToInt32(WebConfigurationManager.AppSettings["freePhotosLimit"]);
            return (userProfile == null) || userProfile.FreePhotosUploaded < freePhotosLimit;
        }
    }
}
