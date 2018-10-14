using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rest_Start.Data;
using Rest_Start.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Rest_Start.Contollers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchText)
        {
            ViewBag.SearchText = searchText;
            var products = _context.Products.ToList();
            if (!string.IsNullOrEmpty(searchText))
            {
                products = products.Where(p => p.Name.Contains(searchText)).ToList();
            }
            return View(products);
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


    }
}