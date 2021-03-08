using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServicioWepAPI.Models;

namespace ServicioWepAPI.Controller
{
    public class CdcsurveysController : ApiController
    {
        private readonly CDCSurveyDBEntities1 db = new CDCSurveyDBEntities1();
  
        // GET: api/cdcsurveys
        public IQueryable<cdcsurvey> Getcdcsurvey()
        {
            return db.cdcsurvey;
        }
        /*
        // GET: api/cdcsurveys/5
        [ResponseType(typeof(cdcsurvey))]
        public IHttpActionResult Getcdcsurvey(Guid id)
        {
            cdcsurvey cdcsurvey = db.cdcsurvey.Find(id);
            if (cdcsurvey == null)
            {
                return NotFound();
            }

            return Ok(cdcsurvey);
        }*/

        // GET: api/cdcsurveys/String
        [ResponseType(typeof(cdcsurvey))]
        public IHttpActionResult Getcdcsurveyss(String id)
        {

            id = id.Replace("-", "/");


            string sql = "SELECT * FROM cdcsurvey WHERE superset like'%"+ id + "%'";
            var cdcsurvey = db.cdcsurvey.SqlQuery(sql, id).ToList();

           
            if (cdcsurvey == null)
            {
                return NotFound();
            }

            return Ok(cdcsurvey);
        }

     
        // PUT: api/cdcsurveys/%
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcdcsurvey(Guid id, cdcsurvey cdcsurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cdcsurvey.id)
            {
                return BadRequest();
            }

            db.Entry(cdcsurvey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cdcsurveyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/cdcsurveys
        [ResponseType(typeof(cdcsurvey))]
        public IHttpActionResult Postcdcsurvey(cdcsurvey cdcsurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cdcsurvey.Add(cdcsurvey);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cdcsurveyExists(cdcsurvey.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cdcsurvey.id }, cdcsurvey);
        }

        // DELETE: api/cdcsurveys/5
        [ResponseType(typeof(cdcsurvey))]
        public IHttpActionResult Deletecdcsurvey(Guid id)
        {
            cdcsurvey cdcsurvey = db.cdcsurvey.Find(id);
            if (cdcsurvey == null)
            {
                return NotFound();
            }

            db.cdcsurvey.Remove(cdcsurvey);
            db.SaveChanges();

            return Ok(cdcsurvey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cdcsurveyExists(Guid id)
        {
            return db.cdcsurvey.Count(e => e.id == id) > 0;
        }
    }
}