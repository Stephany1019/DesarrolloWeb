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
using eDescargasDB.Models;

namespace eDescargasDB.Controllers
{
    public class USUARIOsController : ApiController
    {
        private eDescargasEntities db = new eDescargasEntities();

        // GET: api/USUARIOs
        public IQueryable<USUARIO> GetUSUARIO()
        {
            return db.USUARIO;
        }

        // GET: api/USUARIOs/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult GetUSUARIO(decimal id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            return Ok(uSUARIO);
        }

        // PUT: api/USUARIOs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSUARIO(decimal id, USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSUARIO.Id_usuario)
            {
                return BadRequest();
            }

            db.Entry(uSUARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USUARIOExists(id))
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

        // POST: api/USUARIOs
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult PostUSUARIO(USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USUARIO.Add(uSUARIO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (USUARIOExists(uSUARIO.Id_usuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uSUARIO.Id_usuario }, uSUARIO);
        }

        // DELETE: api/USUARIOs/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult DeleteUSUARIO(decimal id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            db.USUARIO.Remove(uSUARIO);
            db.SaveChanges();

            return Ok(uSUARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USUARIOExists(decimal id)
        {
            return db.USUARIO.Count(e => e.Id_usuario == id) > 0;
        }
    }
}