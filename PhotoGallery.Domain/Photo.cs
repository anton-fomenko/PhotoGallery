using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Domain
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        public string Description { get; set; }
    
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        public string Location { get; set; }

        public string CameraModel { get; set; }

        public int FocalLengthOfLens { get; set; }

        public float Aperture { get; set; }

        public string ShutterSpeed { get; set; }

        public int Iso { get; set; }

        public byte[] ThumbPhoto { get; set; }

        public byte[] LargePhoto { get; set; }

        public virtual List<Album> Photos { get; set; }

        public string UserId { get; set; }
    }
}
