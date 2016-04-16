﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Product
    {
       
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }
    }
}
