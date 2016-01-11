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
using MopPlacesApp.Models;
using System.Web.Helpers;

namespace MopPlacesApp.Controllers
{
    public class GoogleMapsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GoogleMaps
        [Route("api/GoogleMaps/GetFood")]
        public IHttpActionResult GetFood()
        {
            List<GoogleMap> places = db.GoogleMaps.Where(x=>x.Category == "Food").ToList();
            return Ok(places);
        }

        [Route("api/GoogleMaps/GetBars")]
        public IHttpActionResult GetBars()
        {
            List<GoogleMap> places = db.GoogleMaps.Where(x => x.Category == "Bars").ToList();

            return Ok(places);
        }

        [Route("api/GoogleMaps/GetClubs")]
        public IHttpActionResult GetClubs()
        {
            List<GoogleMap> places = db.GoogleMaps.Where(x => x.Category == "Clubs").ToList();

            return Ok(places);
        }

        // GET: api/GoogleMaps/5
        [ResponseType(typeof(GoogleMap))]
        public IHttpActionResult GetGoogleMap(int? id)
        {
            GoogleMap googleMap = db.GoogleMaps.Find(id);
            if (googleMap == null)
            {
                return NotFound();
            }

            return Ok(googleMap);
        }

        // PUT: api/GoogleMaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGoogleMap(int id, GoogleMap googleMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != googleMap.Id)
            {
                return BadRequest();
            }

            db.Entry(googleMap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoogleMapExists(id))
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

        // POST: api/GoogleMaps
        [ResponseType(typeof(GoogleMap))]
        public IHttpActionResult PostGoogleMap(GoogleMap googleMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GoogleMaps.Add(googleMap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = googleMap.Id }, googleMap);
        }

        // DELETE: api/GoogleMaps/5
        [ResponseType(typeof(GoogleMap))]
        public IHttpActionResult DeleteGoogleMap(int id)
        {
            GoogleMap googleMap = db.GoogleMaps.Find(id);
            if (googleMap == null)
            {
                return NotFound();
            }

            db.GoogleMaps.Remove(googleMap);
            db.SaveChanges();

            return Ok(googleMap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GoogleMapExists(int id)
        {
            return db.GoogleMaps.Count(e => e.Id == id) > 0;
        }
    }
}