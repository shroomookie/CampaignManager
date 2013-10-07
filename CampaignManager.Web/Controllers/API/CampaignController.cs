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

namespace CampaignManager.Web.Controllers.API
{
    public class CampaignController : ApiController
    {
        private CampaignManagerEntities db = new CampaignManagerEntities();

        // GET api/Campaign
        public IEnumerable<Campaign> GetCampaigns()
        {
            return db.Campaigns.AsEnumerable();
        }

        // GET api/Campaign/5
        public Campaign GetCampaign(int id)
        {
            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return campaign;
        }

        // PUT api/Campaign/5
        public HttpResponseMessage PutCampaign(int id, Campaign campaign)
        {
            if (ModelState.IsValid && id == campaign.Id)
            {
                db.Entry(campaign).State = EntityState.Modified;

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

        // POST api/Campaign
        public HttpResponseMessage PostCampaign(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                db.Campaigns.Add(campaign);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, campaign);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = campaign.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Campaign/5
        public HttpResponseMessage DeleteCampaign(int id)
        {
            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Campaigns.Remove(campaign);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, campaign);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}