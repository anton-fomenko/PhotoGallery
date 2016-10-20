
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PhotoGallery.Domain;

namespace PhotoGallery.Models
{
    public class CreatePhotoViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}