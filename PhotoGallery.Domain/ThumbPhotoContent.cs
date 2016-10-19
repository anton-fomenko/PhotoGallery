using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Domain
{
    public class ThumbPhotoContent
    {
        [ForeignKey("Photo")]
        public int ThumbPhotoContentId { get; set; }
        public byte[] Bytes { get; set; }
        public virtual Photo Photo { get; set; }
    }
}