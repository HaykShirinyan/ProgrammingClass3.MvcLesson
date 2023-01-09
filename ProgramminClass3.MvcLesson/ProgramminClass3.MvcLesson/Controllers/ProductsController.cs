﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _dbContext
                .Products
                // Include is Entity Framework term for SQL join
                .Include(product => product.Type)
                .Include(product => product.UnitOfMeasure)
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Products.Find(id);

            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(product);
        }
    }
}
