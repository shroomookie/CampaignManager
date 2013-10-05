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
    public class CharacterManagerController : ApiController
    {
        private CampaignManagerEntities db = new CampaignManagerEntities();

        private IQueryable<CharacterManagerDTO> MapCharacters()
        {
            return from c in db.Characters
                select new CharacterManagerDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Gender = c.Gender,
                    RaceInfo = from r in db.Races
                        where c.RaceId == r.Id
                        select new CharacterManagerDTO.Race
                        {
                            Id = r.Id,
                            Name = r.Name
                        },
                    Age = c.Age,
                    Height = c.Height,
                    Weight = c.Weight,
                    Hair = c.Hair,
                    Eyes = c.Eyes,
                    AlignmentInfo = from a in db.Alignments
                                    where c.AlignmentId == a.Id
                                    select new CharacterManagerDTO.Alignment()
                                    {
                                        Id = a.Id,
                                        Name = a.Name,
                                        NameShort = a.NameShort
                                    }
                    };
        }

        // GET api/CharacterManager
        public IEnumerable<CharacterManagerDTO> GetCharacters()
        {
            return MapCharacters().AsEnumerable();
        }

        // GET api/CharacterManager/5
        public CharacterManagerDTO GetCharacter(int id)
        {
            var character = (from c in MapCharacters()
                         where c.Id == id
                         select c).FirstOrDefault();
            if (character == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return character;
        }

        // PUT api/CharacterManager/5
        public HttpResponseMessage PutCharacter(int id, Character character)
        {
            if (ModelState.IsValid && id == character.Id)
            {
                db.Entry(character).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/CharacterManager
        public HttpResponseMessage PostCharacter(Character character)
        {
            //db.Characters.Add(new Character {Name = character.Name});
            //db.SaveChanges();
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, character);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = character.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/CharacterManager/5
        public HttpResponseMessage DeleteCharacter(int id)
        {
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Characters.Remove(character);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, character);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}