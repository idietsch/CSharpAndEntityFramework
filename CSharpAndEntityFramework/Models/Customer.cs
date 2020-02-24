using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpAndEFLibrary.Models {
    public class Customer {

        [Key] //not necessary here, as EF will assume Id is Key
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        public double Sales { get; set; }
        public bool Active { get; set; }

        public Customer() {  }



    }
}
