using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rest_Start.Data;
using Rest_Start.Models;

namespace Rest_Start.Contollers
{
    public class OrdersController : Controller
    {
        private AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order Order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(Order);
                _context.SaveChanges();
            }
            return View();
        }

        public IActionResult List()
        {
            var items = _context.Orders.ToList();
            return View(items);
        }

    }
}