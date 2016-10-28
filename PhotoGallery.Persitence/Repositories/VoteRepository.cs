using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Persistence.Repositories
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        private readonly GalleryContext _context;
        public VoteRepository(GalleryContext context) : base(context)
        {
            _context = context;
        }
    }
}
