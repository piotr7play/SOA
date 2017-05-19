using MagazynSerwer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MagazynSerwer.Models;
using MagazynSerwer.Context;

namespace MagazynSerwer.Repositories
{
    public class MagazynRepository : IMagazynRepository
    {
        private MagazynContext db = new MagazynContext();

        public int Add(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();

            return article.Id;
        }

        public bool Delete(int id)
        {
            Article a = db.Articles.Find(id);
            if(a == null)
            {
                return false;
            }
            db.Articles.Remove(a);
            db.SaveChanges();

            return true;
        }

        public Article Get(int id)
        {
            return db.Articles.Find(id);
        }

        public List<Article> GetAll()
        {
            return db.Articles.ToList();
        }

        public Article Update(Article article)
        {
            Article a = db.Articles.Find(article.Id);
            if (a == null)
            {
                return null;
            }
            a = article;
            db.SaveChanges();

            return article;
        }
    }
}
