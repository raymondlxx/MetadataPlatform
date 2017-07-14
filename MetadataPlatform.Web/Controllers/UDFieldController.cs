using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MetadataPlatform.Web.Models;

namespace MetadataPlatform.Web.Controllers
{
    public class UDFieldController : ApiController
    {
        private MetadataPlatformWebContext db = new MetadataPlatformWebContext();

        // GET: api/UDField
        public IQueryable<UDFieldEntity> GetUDFieldEntities()
        {
            return db.UDFieldEntities;
        }

        // GET: api/UDField/5
        [ResponseType(typeof(UDFieldEntity))]
        public async Task<IHttpActionResult> GetUDFieldEntity(string id)
        {
            UDFieldEntity uDFieldEntity = await db.UDFieldEntities.FindAsync(id);
            if (uDFieldEntity == null)
            {
                return NotFound();
            }

            return Ok(uDFieldEntity);
        }

        // PUT: api/UDField/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUDFieldEntity(string id, UDFieldEntity uDFieldEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uDFieldEntity.ID)
            {
                return BadRequest();
            }

            db.Entry(uDFieldEntity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UDFieldEntityExists(id))
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

        // POST: api/UDField
        [ResponseType(typeof(UDFieldEntity))]
        public async Task<IHttpActionResult> PostUDFieldEntity(UDFieldEntity uDFieldEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UDFieldEntities.Add(uDFieldEntity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UDFieldEntityExists(uDFieldEntity.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uDFieldEntity.ID }, uDFieldEntity);
        }

        // DELETE: api/UDField/5
        [ResponseType(typeof(UDFieldEntity))]
        public async Task<IHttpActionResult> DeleteUDFieldEntity(string id)
        {
            UDFieldEntity uDFieldEntity = await db.UDFieldEntities.FindAsync(id);
            if (uDFieldEntity == null)
            {
                return NotFound();
            }

            db.UDFieldEntities.Remove(uDFieldEntity);
            await db.SaveChangesAsync();

            return Ok(uDFieldEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UDFieldEntityExists(string id)
        {
            return db.UDFieldEntities.Count(e => e.ID == id) > 0;
        }
    }
}