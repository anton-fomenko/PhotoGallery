using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Domain
{
    public class PhotoBytesContent
    {
        [ForeignKey("Photo")]
        public int PhotoBytesContentId { get; set; }
        public virtual Photo Photo { get; set; }
        public byte[] OriginalPhoto { get; set; }
        public byte[] MediumPhoto { get; set; }
        public byte[] ThumbPhoto { get; set; }
    }
}
