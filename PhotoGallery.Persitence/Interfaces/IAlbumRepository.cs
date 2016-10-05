﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;

namespace PhotoGallery.Persistence.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAlbumsByUserId(string userId);
    }
}