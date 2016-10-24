using System.Web;
using PhotoGallery.Attributes;

namespace PhotoGallery.Models
{
    public class CreatePhotoViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [MaxFileSize(500 * 1024, 
            ErrorMessage = "Maximum allowed file size is 500 kilobytes")]
        public HttpPostedFileBase File { get; set; }
    }
}