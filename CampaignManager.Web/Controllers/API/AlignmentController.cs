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
    public class AlignmentController : ApiController
    {
        private CampaignManagerEntities db = new CampaignManagerEntities();

        private IQueryable<AlignmentDTO> MapAlignments()
        {
            return from a in db.Alignments
                select new AlignmentDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    CharacterClasses = from c in a.AlignmentsCharacterClasses
                        select new AlignmentDTO.CharacterClass
                        {
                            Id = c.CharacterClass.Id,
                            Name = c.CharacterClass.Name
                        }
                };
        }

        public IEnumerable<AlignmentDTO> GetAlignments()
        {
            return MapAlignments().AsEnumerable();
        }

        public AlignmentDTO GetAlignment(int id)
        {
            var alignment = (from a in MapAlignments()
                where a.Id == id
                select a).FirstOrDefault();
            if (alignment == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return alignment;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}