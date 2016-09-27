using System;
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

        public byte[] ThumbPhoto { get; set; }

        public byte[] LargePhoto { get; set; }
    }
}
