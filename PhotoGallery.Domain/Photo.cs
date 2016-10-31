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

        public string UserId { get; set; }

        public virtual List<Album> Albums { get; set; }

        /// <summary>
        /// List of Albums where this Photo is set as a Main Photo
        /// </summary>
        public virtual List<Album> MainPhotoAlbums { get; set; }

        public virtual List<Vote> Votes { get; set; }

        public virtual PhotoBytesContent PhotoBytesContent { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
