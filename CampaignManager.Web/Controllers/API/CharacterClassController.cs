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
    public class CharacterClassController : ApiController
    {
        private CampaignManagerEntities db = new CampaignManagerEntities();

        private IQueryable<CharacterClassDTO> MapCharacterClasses()
        {
            return from c in db.CharacterClasses
                   select new CharacterClassDTO
                   {
                       Id = c.Id,
                       Name = c.Name,
                       Type = c.Type,
                       HitDie = c.HitDie,
                       SkillPoints = c.SkillPoints,
                       AttackBonusType = c.AttackBonusType,
                       AttackBonusValues = from bab in db.BaseAttackBonuses
                                           where bab.Type == c.AttackBonusType
                                           && bab.HitDice <= 20
                                           select new CharacterClassDTO.AttackBonusValue
                                           {
                                               HitDice = bab.HitDice,
                                               Value = bab.Value
                                           },
                       FortitudeType = c.FortitudeType,
                       ReflexType = c.ReflexType,
                       WillpowerType = c.WillpowerType,
                       Source = c.Source,
                       Hidden = c.Hidden,
                       SkillNames = from s in c.ClassSkills
                                    select new CharacterClassDTO.SkillName
                                    {
                                        Id = s.Skill.Id,
                                        Name = s.Skill.Name
                                    }
                   };
        }

        public IEnumerable<CharacterClassDTO> GetCharacterClasses()
        {
            return MapCharacterClasses().AsEnumerable();
        }

        public CharacterClassDTO GetCharacterClass(int id)
        {
            var characterClass = (from c in MapCharacterClasses()
                                  where c.Id == id
                                  select c).FirstOrDefault();
            if (characterClass == null)
            {
                throw new HttpResponseException(
                   Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return characterClass;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}