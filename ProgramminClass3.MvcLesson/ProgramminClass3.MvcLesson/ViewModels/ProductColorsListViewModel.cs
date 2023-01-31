﻿using ProgramminClass3.MvcLesson.Data.Migrations;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.ViewModels
{
    public class ProductColorsListViewModel
    {
        public List<ProductColor> ProductColors { get; set; }

        public List<Color> Colors { get; set; }

        public int ProductId { get; set; }
        
        public int ColorId { get; set; }
    }
}