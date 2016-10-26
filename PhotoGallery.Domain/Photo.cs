using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Domain
{
    public class Photo
    {
        public int PhotoId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

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
        public string UserId { get; set; }

        public virtual List<Album> Albums { get; set; }
        public virtual PhotoBytesContent PhotoBytesContent { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
