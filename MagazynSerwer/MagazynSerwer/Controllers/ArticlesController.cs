using MagazynSerwer.Interfaces;
using MagazynSerwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MagazynSerwer.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly IMagazynRepository mRepo;
        private readonly ILogger mLogger;

        public ArticlesController(IMagazynRepository mr, ILogger logger)
        {
            mRepo = mr;
            mLogger = logger;
        }

        public IEnumerable<Article> GetArticles()
        {
            mLogger.Write("Get all articles was called", LogLevel.INFO);
            return mRepo.GetAll();
        }

        public IHttpActionResult GetArticle(int id)
        {
            mLogger.Write("Get article was called", LogLevel.INFO);
            Article art = mRepo.Get(id);
            if (art == null)
            {
                return NotFound();
            }

            return Ok(art);
        }

        [ResponseType(typeof(Article))]
        public IHttpActionResult PutArticle(int id, Article article)
        {
            mLogger.Write("Put article was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.Id)
            {
                return BadRequest();
            }

            Article a = mRepo.Update(article);
            if (a == null)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Article))]
        public IHttpActionResult PostArticle(Article article)
        {
            mLogger.Write("Post article was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mRepo.Add(article);

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        public IHttpActionResult DeleteArtist(int id)
        {
            mLogger.Write("Delete article was called", LogLevel.INFO);
            if (!mRepo.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
