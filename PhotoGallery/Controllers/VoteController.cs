using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Controllers
{
    public class VoteController : ApiController
    {
        private readonly IPhotoService _photoService;

        public VoteController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        // GET: api/Vote
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vote/5
        public int Get(int id)
        { 
            return _photoService.GetLikes(id);
        }

        // POST: api/Vote
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vote/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vote/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources
                _photoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
