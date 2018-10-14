using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rest_Start.Models
{
    public class Search
    {
        public List<Product> Product;
        public SelectList genres;
        public string ProductGenre { get; set; }
    }
}
