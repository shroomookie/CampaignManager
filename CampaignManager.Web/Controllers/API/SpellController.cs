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

using CampaignManager.DTO;

namespace CampaignManager.Web.Controllers.API
{
    public class SpellController : ApiController
    {
        private CampaignManagerEntities db = new CampaignManagerEntities();

        private IQueryable<SpellDTO> MapSpells()
        {
            return from s in db.Spells
                   select new SpellDTO()
                   {
                       Id = s.Id,
                       Name = s.Name,
                       School = s.School,
                       SubSchool = s.SubSchool,
                       Descriptor = s.Descriptor,
                       CastingTime = s.CastingTime,
                       Components = s.Components,
                       Range = s.Range,
                       Area = s.Area,
                       Effect = s.Effect,
                       Target = s.Targets,
                       Duration = s.Duration,
                       SavingThrow = s.SavingThrow,
                       SpellResistance = s.SpellResistance,
                       ShortDescription = s.ShortDescription,
                       Description = s.Description,
                       DescriptionFormatted = s.DescriptionFormatted,
                       Source = s.Source,
                       Hidden = s.Hidden,
                       Levels = from l in s.SpellLevels
                                select new SpellDTO.Level()
                                {
                                    CharacterClass = l.CharacterClass.Name,
                                    SpellLevel = l.Level
                                }
                   };
        }

        // GET api/Spell
        public IEnumerable<SpellDTO> GetSpells()
        {
            return MapSpells().AsEnumerable();
        }

        // GET api/Spell/5
        public SpellDTO GetSpell(int id)
        {
            var spell = (from s in MapSpells()
                         where s.Id == id
                         select s).FirstOrDefault();
            if (spell == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return spell;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}