using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Services.DataObjects
{
    public class ListOfPhotosDto
    {
        public bool CanBeChanged { get; set; }
        public List<PhotoDto> PhotoDtoList { get; set; }
    }
}
