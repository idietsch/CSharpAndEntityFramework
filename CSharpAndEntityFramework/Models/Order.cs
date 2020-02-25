﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpAndEFLibrary.Models {

    public class Order {

        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Description { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customerx { get; set; }

        public override string ToString() => $"{Id}|{Description}|{Amount}|{CustomerId}|{Customerx}";

        public virtual List<Orderline> Orderlines { get; set; }

        public Order() {  }



    }
}
