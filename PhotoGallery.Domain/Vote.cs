using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Domain
{
    public class Vote
    {
        public int Id { get; set; }
        public virtual Photo Photo { get; set; }
        public bool Liked { get; set; }
    }
}
