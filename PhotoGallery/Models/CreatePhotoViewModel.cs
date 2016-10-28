using System.ComponentModel.DataAnnotations;
using System.Web;
using PhotoGallery.Attributes;
using System;

namespace PhotoGallery.Models
{
    public class CreatePhotoViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [MaxFileSize(500 * 1024,
            ErrorMessage = "Maximum allowed file size is 500 kilobytes. Only JPEG files are allowed."),
            Required]
        public HttpPostedFileBase File { get; set; }

        public DateTime? CreationDate { get; set; }

        public string Location { get; set; }

        [Display(Name = "Camera Model")]
        public string CameraModel { get; set; }

        [Display(Name = "Focal Length of the Lens")]
        public int? FocalLengthOfLens { get; set; }

        public float? Aperture { get; set; }

        [Display(Name = "Shutter Speed")]
        public string ShutterSpeed { get; set; }

        public int? Iso { get; set; }

        public bool? Flash { get; set; }
    }
}