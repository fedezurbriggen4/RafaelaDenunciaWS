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
    public class TipoDenunciasController : ApiController
    {
        private RafaelaDenunciaEntities db = new RafaelaDenunciaEntities();

        // GET: api/TipoDenuncias
        public TipoDenuncias[] GetTipoDenuncias()
        {
            var result = db.TipoDenuncias.ToArray();
            return result;
        }

        // GET: api/TipoDenuncias/5
        [ResponseType(typeof(TipoDenuncias))]
        public IHttpActionResult GetTipoDenuncias(int id)
        {
            TipoDenuncias tipoDenuncias = db.TipoDenuncias.Find(id);
            if (tipoDenuncias == null)
            {
                return NotFound();
            }

            return Ok(tipoDenuncias);
        }

        // PUT: api/TipoDenuncias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoDenuncias(int id, TipoDenuncias tipoDenuncias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDenuncias.tipoDenuncia)
            {
                return BadRequest();
            }

            db.Entry(tipoDenuncias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDenunciasExists(id))
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

        // POST: api/TipoDenuncias
        [ResponseType(typeof(TipoDenuncias))]
        public IHttpActionResult PostTipoDenuncias(TipoDenuncias tipoDenuncias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoDenuncias.Add(tipoDenuncias);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TipoDenunciasExists(tipoDenuncias.tipoDenuncia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tipoDenuncias.tipoDenuncia }, tipoDenuncias);
        }

        // DELETE: api/TipoDenuncias/5
        [ResponseType(typeof(TipoDenuncias))]
        public IHttpActionResult DeleteTipoDenuncias(int id)
        {
            TipoDenuncias tipoDenuncias = db.TipoDenuncias.Find(id);
            if (tipoDenuncias == null)
            {
                return NotFound();
            }

            db.TipoDenuncias.Remove(tipoDenuncias);
            db.SaveChanges();

            return Ok(tipoDenuncias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoDenunciasExists(int id)
        {
            return db.TipoDenuncias.Count(e => e.tipoDenuncia == id) > 0;
        }
    }
}