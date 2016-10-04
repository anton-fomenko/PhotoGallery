using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;

namespace PhotoGallery.Services.Interfaces
{
    public interface IPhotoService
    {
        List<Photo> GetPhotosOfTheUser(string userId);
    }
}
