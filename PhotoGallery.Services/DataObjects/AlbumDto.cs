using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;

namespace PhotoGallery.Services.DataObjects
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<PhotoDto> Photos { get; set; }
        public virtual Photo MainPhoto { get; set; }
        public string UserId { get; set; }
    }
}
