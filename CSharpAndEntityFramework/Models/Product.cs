﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CSharpAndEFLibrary.Models {
    public class Product {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual List<Orderline> Orderlines { get; set; }

        public override string ToString() => $"{Id}|{Code}|{Name}|{Price}";

        public Product() { }
        
    }
}
