using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazynSerwer.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
    }
}
