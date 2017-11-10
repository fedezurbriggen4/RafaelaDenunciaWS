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
using ServicioUsuario.Datos;

namespace ServicioUsuario.Controllers
{
    public class DenunciasController : ApiController
    {
        private RafaelaDenunciaEntities db = new RafaelaDenunciaEntities();

        // GET: api/Denuncias
        public IQueryable<Denuncias> GetDenuncias()
        {
            return db.Denuncias;
        }

        // GET: api/Denuncias/5
        [ResponseType(typeof(Denuncias))]
        public IHttpActionResult GetDenuncias(int id)
        {
            Denuncias denuncias = db.Denuncias.Find(id);
            if (denuncias == null)
            {
                return NotFound();
            }

            return Ok(denuncias);
        }

        // PUT: api/Denuncias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDenuncias(int id, Denuncias denuncias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denuncias.numDenuncia)
            {
                return BadRequest();
            }

            db.Entry(denuncias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenunciasExists(id))
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

        // POST: api/Denuncias
        [ResponseType(typeof(Denuncias))]
        public IHttpActionResult PostDenuncias(Denuncias denuncias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Denuncias.Add(denuncias);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DenunciasExists(denuncias.numDenuncia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = denuncias.numDenuncia }, denuncias);
        }

        // DELETE: api/Denuncias/5
        [ResponseType(typeof(Denuncias))]
        public IHttpActionResult DeleteDenuncias(int id)
        {
            Denuncias denuncias = db.Denuncias.Find(id);
            if (denuncias == null)
            {
                return NotFound();
            }

            db.Denuncias.Remove(denuncias);
            db.SaveChanges();

            return Ok(denuncias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DenunciasExists(int id)
        {
            return db.Denuncias.Count(e => e.numDenuncia == id) > 0;
        }
    }
}