using MagazynSerwer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MagazynSerwer.Models;
using System.Data;
using Npgsql;
using Dapper;

namespace MagazynSerwer.Repositories
{
    public class MagazynRepositoryDapper : IMagazynRepository
    {
        private IDbConnection _db = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MagazynContext"].ConnectionString);

        public int Add(Article article)
        {
            int rowsAffected = _db.Execute("INSERT INTO \"Articles\" values (@Id, @Name, @Quantity, @Price)", new { Id = article.Id, Name = article.Name, Quantity = article.Quantity, Price = article.Price });

            if (rowsAffected > 0)
            {
                return article.Id;
            }
            return 0;
        }

        public bool Delete(int id)
        {
            int rowsAffected = _db.Execute("DELETE FROM \"Articles\" WHERE \"Id\" = @ArticleId", new { ArticleId = id});

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public Article Get(int id)
        {
            return _db.Query<Article>("SELECT * FROM \"Articles\" WHERE \"Id\" = @ArticleID", new { ArticleID = id }).SingleOrDefault();
        }

        public List<Article> GetAll()
        {
            return _db.Query<Article>("SELECT * FROM \"Articles\"").ToList();
        }

        public Article Update(Article article)
        {
            int rowsAffected = _db.Execute("UPDATE \"Articles\" SET \"Name\" = @Name ,\"Quantity\" = @Quantity, \"Price\" = @Price WHERE \"Id\" = " + article.Id, article);

            if (rowsAffected > 0)
            {
                return article;
            }
            return null;
        }
    }
}
