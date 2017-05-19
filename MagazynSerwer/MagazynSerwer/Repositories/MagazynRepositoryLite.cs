using LiteDB;
using MagazynSerwer.Interfaces;
using MagazynSerwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazynSerwer.Repositories
{
    public class MagazynRepositoryLite : IMagazynRepository
    {
        private readonly string _articlesConnection = @"C:\Users\Lenovo\Documents\Visual Studio 2015\Projects\MagazynSerwer\articles";

        public List<Article> GetAll()
        {
            using (var db = new LiteDatabase(this._articlesConnection))
            {
                var repository = db.GetCollection<Article>("articles");
                var results = repository.FindAll();
                return results.ToList();
            }
        }

        public int Add(Article article)
        {
            using (var db = new LiteDatabase(this._articlesConnection))
            {
                var repository = db.GetCollection<Article>("articles");
                repository.Insert(article);
                return article.Id;

            }
        }

        public Article Get(int id)
        {
            using (var db = new LiteDatabase(this._articlesConnection))
            {
                var repository = db.GetCollection<Article>("articles");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Article Update(Article article)
        {
            using (var db = new LiteDatabase(this._articlesConnection))
            {
                var repository = db.GetCollection<Article>("articles");
                if (repository.Update(article))
                    return article;
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._articlesConnection))
            {
                var repository = db.GetCollection<Article>("articles");
                return repository.Delete(id);
            }
        }
    }
}
