using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Services.DataObjects
{
    public class DeletePhotosFromAlbumModel
    {
        public int AlbumId { get; set; }
        public List<int> ArrayOfPhotoIds { get; set; }
    }
}
