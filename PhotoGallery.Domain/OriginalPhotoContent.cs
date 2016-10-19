using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Domain
{
    public class OriginalPhotoContent
    {
        [ForeignKey("Photo")]
        public int OriginalPhotoContentId { get; set; }
        public byte[] Bytes { get; set; }
        public virtual Photo Photo { get; set; }
    }
}