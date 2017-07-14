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
    public class UDObjectController : ApiController
    {
        private MetadataPlatformWebContext db = new MetadataPlatformWebContext();

        // GET: api/UDObject
        public IQueryable<UDObjectEntity> GetUDObjectEntities()
        {
            return db.UDObjectEntities;
        }

        // GET: api/UDObject/5
        [ResponseType(typeof(UDObjectEntity))]
        public async Task<IHttpActionResult> GetUDObjectEntity(string id)
        {
            UDObjectEntity uDObjectEntity = await db.UDObjectEntities.FindAsync(id);
            if (uDObjectEntity == null)
            {
                return NotFound();
            }

            return Ok(uDObjectEntity);
        }

        // PUT: api/UDObject/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUDObjectEntity(string id, UDObjectEntity uDObjectEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uDObjectEntity.ID)
            {
                return BadRequest();
            }

            db.Entry(uDObjectEntity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UDObjectEntityExists(id))
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

        // POST: api/UDObject
        [ResponseType(typeof(UDObjectEntity))]
        public async Task<IHttpActionResult> PostUDObjectEntity(UDObjectEntity uDObjectEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UDObjectEntities.Add(uDObjectEntity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UDObjectEntityExists(uDObjectEntity.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uDObjectEntity.ID }, uDObjectEntity);
        }

        // DELETE: api/UDObject/5
        [ResponseType(typeof(UDObjectEntity))]
        public async Task<IHttpActionResult> DeleteUDObjectEntity(string id)
        {
            UDObjectEntity uDObjectEntity = await db.UDObjectEntities.FindAsync(id);
            if (uDObjectEntity == null)
            {
                return NotFound();
            }

            db.UDObjectEntities.Remove(uDObjectEntity);
            await db.SaveChangesAsync();

            return Ok(uDObjectEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UDObjectEntityExists(string id)
        {
            return db.UDObjectEntities.Count(e => e.ID == id) > 0;
        }
    }
}