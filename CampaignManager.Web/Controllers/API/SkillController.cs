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
    public class SkillController : ApiController
    {
        private CampaignManagerEntities db = new CampaignManagerEntities();

        private IQueryable<SkillDTO> MapSkills()
        {
            return from s in db.Skills
                   select new SkillDTO
                   {
                       Id = s.Id,
                       Name = s.Name
                   };
        }

        // GET api/Skill
        public IEnumerable<SkillDTO> GetSkills()
        {
            return MapSkills().AsEnumerable();
        }

        // GET api/Skill/5
        public SkillDTO GetSkill(int id)
        {
            var skill = (from s in MapSkills()
                         where s.Id == id
                         select s).FirstOrDefault();
            if (skill == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return skill;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}