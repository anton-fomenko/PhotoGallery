using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Persistence.Entities
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

        public Album Album { get; set; }
    }
}
