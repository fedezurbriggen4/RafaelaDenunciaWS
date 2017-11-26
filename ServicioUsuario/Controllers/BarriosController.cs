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
    public class BarriosController : ApiController
    {
        private RafaelaDenunciaEntities db = new RafaelaDenunciaEntities();

        // GET: api/Barrios
        public List<Barrios> GetBarrios()
        {
            var result = db.Barrios.ToList();
            return result;
        }

        // GET: api/Barrios/5
        [ResponseType(typeof(Barrios))]
        public IHttpActionResult GetBarrios(int id)
        {
            Barrios barrios = db.Barrios.Find(id);
            if (barrios == null)
            {
                return NotFound();
            }

            return Ok(barrios);
        }

        // PUT: api/Barrios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBarrios(int id, Barrios barrios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != barrios.idBarrio)
            {
                return BadRequest();
            }

            db.Entry(barrios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarriosExists(id))
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

        // POST: api/Barrios
        [ResponseType(typeof(Barrios))]
        public IHttpActionResult PostBarrios(Barrios barrios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Barrios.Add(barrios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = barrios.idBarrio }, barrios);
        }

        // DELETE: api/Barrios/5
        [ResponseType(typeof(Barrios))]
        public IHttpActionResult DeleteBarrios(int id)
        {
            Barrios barrios = db.Barrios.Find(id);
            if (barrios == null)
            {
                return NotFound();
            }

            db.Barrios.Remove(barrios);
            db.SaveChanges();

            return Ok(barrios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BarriosExists(int id)
        {
            return db.Barrios.Count(e => e.idBarrio == id) > 0;
        }
    }
}