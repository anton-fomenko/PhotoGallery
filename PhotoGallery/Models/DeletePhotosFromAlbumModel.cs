using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class DeletePhotosFromAlbumModel
    {
        public int AlbumId { get; set; }
        public List<int> ArrayOfPhotoIds { get; set; }
    }
}