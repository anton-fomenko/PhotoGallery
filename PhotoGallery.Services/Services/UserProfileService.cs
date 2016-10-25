using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
