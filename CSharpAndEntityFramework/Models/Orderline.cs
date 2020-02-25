using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CSharpAndEFLibrary.Models {
    public class Orderline {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public virtual Order Orderx { get; set; }

        public virtual Product Productx { get; set; } //get whole product line back

        public Orderline() {  }
    }
}
