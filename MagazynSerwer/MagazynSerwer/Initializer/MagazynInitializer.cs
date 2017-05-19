using MagazynSerwer.Context;
using MagazynSerwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazynSerwer.Initializer
{
    public class MagazynInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MagazynContext>
    {
        protected override void Seed(MagazynContext context)
        {
            List<Article> defaultArticles = new List<Article>();
            defaultArticles.Add(new Article { Name = "FirstArticle", Quantity = 100, Price = 0.99});
            defaultArticles.Add(new Article { Name = "SecondArticle", Quantity = 200, Price = 1.99 });
            foreach(Article item in defaultArticles)
            {
                context.Articles.Add(item);
            }
            context.SaveChanges();
        }
    }
}
