using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CampaignManager.Web.Models.DTO;

namespace CampaignManager.Web.Controllers.API
{
    public class RaceController : ApiController
    {
        private CampaignManagerEntities db = new CampaignManagerEntities();

        private IQueryable<RaceDTO> MapRaces()
        {
            return from r in db.Races
                select new RaceDTO()
                {
                    Id = r.Id,
                    Name = r.Name
                };
        }

        // GET api/Race
        public IEnumerable<RaceDTO> GetRaces()
        {
            return MapRaces().AsEnumerable();
        }

        // GET api/Race/5
        public RaceDTO GetRace(int id)
        {
            var race = (from r in MapRaces()
                         where r.Id == id
                         select r).FirstOrDefault();
            if (race == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return race; ;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}