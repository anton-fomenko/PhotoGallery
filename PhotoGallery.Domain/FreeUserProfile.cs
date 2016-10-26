using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Domain
{
    public class FreeUserProfile : UserProfile
    {
        public int FreePhotosUploaded { get; set; }
        public int FreeAlbumsCreated { get; set; }
    }
}
