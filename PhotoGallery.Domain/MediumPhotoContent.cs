using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoGallery.Domain
{
    public class MediumPhotoContent
    {
        [ForeignKey("Photo")]
        public int MediumPhotoContentId { get; set; }
        public byte[] Bytes { get; set; }
        public virtual Photo Photo { get; set; }
    }
}