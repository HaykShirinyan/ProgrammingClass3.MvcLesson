﻿using System.ComponentModel.DataAnnotations;

namespace ProgramminClass3.MvcLesson.Models
{
    public class UnitOfMeasure
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }

}


