using MagazynSerwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazynSerwer.Interfaces
{
    public interface IMagazynRepository
    {
        List<Article> GetAll();
        int Add(Article article);
        Article Get(int id);
        Article Update(Article article);
        bool Delete(int id);
    }
}
