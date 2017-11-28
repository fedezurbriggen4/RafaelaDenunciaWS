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
    public class PerdidasController : ApiController
    {
        private RafaelaDenunciaEntities db = new RafaelaDenunciaEntities();

        // GET: api/Perdidas
        public List<Perdidas> GetPerdidas()
        {
            var result = db.Perdidas.ToList();
            return result;
        }

        // GET: api/Perdidas/5
        [ResponseType(typeof(Perdidas))]
        public IHttpActionResult GetPerdidas(int id)
        {
            Perdidas perdidas = db.Perdidas.Find(id);
            if (perdidas == null)
            {
                return NotFound();
            }

            return Ok(perdidas);
        }

        // PUT: api/Perdidas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerdidas(int id, Perdidas perdidas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perdidas.idPerdida)
            {
                return BadRequest();
            }

            db.Entry(perdidas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerdidasExists(id))
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

        // POST: api/Perdidas
        [ResponseType(typeof(Perdidas))]
        public IHttpActionResult PostPerdidas(Perdidas perdidas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Perdidas.Add(perdidas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perdidas.idPerdida }, perdidas);
        }

        // DELETE: api/Perdidas/5
        [ResponseType(typeof(Perdidas))]
        public IHttpActionResult DeletePerdidas(int id)
        {
            Perdidas perdidas = db.Perdidas.Find(id);
            if (perdidas == null)
            {
                return NotFound();
            }

            db.Perdidas.Remove(perdidas);
            db.SaveChanges();

            return Ok(perdidas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerdidasExists(int id)
        {
            return db.Perdidas.Count(e => e.idPerdida == id) > 0;
        }
    }
}