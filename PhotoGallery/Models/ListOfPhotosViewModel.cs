using PhotoGallery.Services.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class ListOfPhotosViewModel
    {
        public bool CanBeChanged { get; set; }
        public List<PhotoDto> PhotoDtoList { get; set;}
    }
}