using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class AlbumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}