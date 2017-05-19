using MagazynSerwer.Context;
using MagazynSerwer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace MagazynSerwer.Controllers
{
    public class ODataArticlesController : ODataController
    {
        MagazynContext db = new MagazynContext();

        [HttpGet]
        [ODataRoute("AveragePrice")]
        public IHttpActionResult AveragePrice()
        {
            int i = 0;
            double sum = 0;
            var articles = db.Articles;
            foreach(var art in articles)
            {
                sum += art.Price;
                i++;
            }
            double rate = sum/i;
            return Ok(rate);
        }

        [EnableQuery]
        public IQueryable<Article> Get()
        {
            return db.Articles;
        }

        [EnableQuery]
        public SingleResult<Article> Get([FromODataUri] int key)
        {
            IQueryable<Article> result = db.Articles.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Article ar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Articles.Add(ar);
            await db.SaveChangesAsync();
            return Created(ar);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Article update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await db.Articles.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Articles.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool ArticleExists(int key)
        {
            return db.Articles.Any(p => p.Id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
