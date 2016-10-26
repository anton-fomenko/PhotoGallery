using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoGallery.Domain;

namespace PhotoGallery.Models
{
    public class CreateAlbumViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Photo> PhotosOfTheUser { get; set; }
        public int SelectedMainPhotoId { get; set; }
    }
}