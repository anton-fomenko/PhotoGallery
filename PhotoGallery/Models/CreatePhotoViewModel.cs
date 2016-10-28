using System.ComponentModel.DataAnnotations;
using System.Web;
using PhotoGallery.Attributes;
using System;

namespace PhotoGallery.Models
{
    public class CreatePhotoViewModel
    {
        [MaxFileSize(500 * 1024,
            ErrorMessage = "Maximum allowed file size is 500 kilobytes. Only JPEG files are allowed."),
            Required]
        public HttpPostedFileBase File { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Creation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm}")]
        public DateTime? CreationDate { get; set; }

        public string Location { get; set; }

        [Display(Name = "Camera Model")]
        public string CameraModel { get; set; }

        [Display(Name = "Focal Length of the Lens")]
        [Range(0, int.MaxValue)]
        public int? FocalLengthOfLens { get; set; }

        [Range(0.0f, float.MaxValue)]
        public float? Aperture { get; set; }

        [Display(Name = "Shutter Speed")]
        public string ShutterSpeed { get; set; }

        [Range(0, int.MaxValue)]
        public int? Iso { get; set; }

        public bool? Flash { get; set; }
    }
}