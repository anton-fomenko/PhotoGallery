using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoGallery.Domain;

namespace PhotoGallery.Models
{
    public class AddToItemViewModel
    {
        public Photo Photo { get; set; }
        public List<Album> Albums { get; set; }
    }
}