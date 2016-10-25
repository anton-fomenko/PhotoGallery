﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Domain
{
    public abstract class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }
        public int UserIdentityId { get; set; }
    }
}
