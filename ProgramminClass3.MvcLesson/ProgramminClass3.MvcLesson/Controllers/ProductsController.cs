﻿using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _dbContext.Products.ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
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

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Products.Find(id);
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

            return View(product);
        }
    }
}
