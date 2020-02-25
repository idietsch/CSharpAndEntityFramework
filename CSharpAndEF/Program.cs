using CSharpAndEFLibrary.Models;
using CSharpAndEntityFramework;
using System;
using System.Linq;

namespace CSharpAndEF {
    class Program {
        static void Main(string[] args) {
            var context = new AppDbContext();
            //AddCustomer(context);
            //AddOrder(context);
            //AddOrderline(context);
            //AddProduct(context);
            GetAllCustomers(context);
            GetAllOrders(context);
            GetAllProducts(context);
            //GetCustomerByPk(context);
            //GetOrderlines(context);
            //UpdateCustomer(context);
            //UpdateCustomerSales(context);
            //UpdateProduct(context);
            //DeleteCustomer(context);
            //DeleteOrder(context);
        }
        static void AddCustomer(AppDbContext context) {
            var cust1 = new Customer { Id = 0, Name = "Name 1", Sales = 1500, Active = true};
            var cust2 = new Customer { Id = 0, Name = "Name 2", Sales = 2000, Active = true };
            var cust3 = new Customer { Id = 0, Name = "Name 3", Sales = 1000, Active = false };
            var cust4 = new Customer { Id = 0, Name = "Name 4", Sales = 2500, Active = true };
            var cust5 = new Customer { Id = 0, Name = "Name 5", Sales = 3000, Active = true };
            context.AddRange(cust1, cust2, cust3, cust4, cust5);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Customer Add Failed");
            return;

        }
        static void AddOrder(AppDbContext context) {
            var order1 = new Order { Id = 0, Description = "Order 1", Amount = 20, CustomerId = 1 };
            var order2 = new Order { Id = 0, Description = "Order 2", Amount = 50, CustomerId = 1 };
            var order3 = new Order { Id = 0, Description = "Order 3", Amount = 10, CustomerId = 2 };
            var order4 = new Order { Id = 0, Description = "Order 4", Amount = 15, CustomerId = 2 };
            var order5 = new Order { Id = 0, Description = "Order 5", Amount = 25, CustomerId = 3 };
            var order6 = new Order { Id = 0, Description = "Order 6", Amount = 10, CustomerId = 3 };
            var order7 = new Order { Id = 0, Description = "Order 7", Amount = 15, CustomerId = 4 };
            var order8 = new Order { Id = 0, Description = "Order 8", Amount = 20, CustomerId = 4 };
            var order9 = new Order { Id = 0, Description = "Order 9", Amount = 10, CustomerId = 5 };
            var order10 = new Order { Id = 0, Description = "Order 10", Amount = 25, CustomerId = 5 };
        context.AddRange(order1,order2,order3,order4,order5,order6,order7,order8,order9,order10);
        var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Order Add Failed");
            return;
        
        }
        //static void AddOrder(AppDbContext context) {
        //    var ord = new Order {
        //        Id = 0,
        //        CustomerId = 4,
        //        Amount = 200,
        //        Description = "Boiga",
        //    };
        //    context.Orders.Add(ord);
        //    var rowsAffected = context.SaveChanges();
        //    if (rowsAffected == 0) throw new Exception("Order Add Failed");
        //    else { 
        //    Console.WriteLine("Add Successful");
        //    }
        //}
        //Alternatively
        static void AddOrderline(AppDbContext context) {
            var order = context.Orders.SingleOrDefault(o => o.Description == "Order 1");
            var product = context.Products.SingleOrDefault(p => p.Code == "P1");
            var orderline = new Orderline {
                Id = 0,
                ProductId = product.Id,
                OrderId = order.Id,
                Quantity = 1
            };
            context.Orderlines.Add(orderline);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("OrderLine Insert Failed");
        }
        static void AddProduct(AppDbContext context) {
            var product1 = new Product { Id = 0, Price = 100, Name = "Prod 1", Code = "P1" };
            var product2 = new Product { Id = 0, Price = 150, Name = "Prod 2", Code = "P2" };
            var product3 = new Product { Id = 0, Price = 120, Name = "Prod 3", Code = "P3" };
            var product4 = new Product { Id = 0, Price = 100, Name = "Prod 4", Code = "P4" };
            var product5 = new Product { Id = 0, Price = 200, Name = "Prod 5", Code = "P5" };
            context.AddRange(product1, product2, product3, product4, product5);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("fail");
            return;
        }
        static void GetAllCustomers(AppDbContext context) {
            var custs = context.Customers.ToList();
            foreach(var c in custs) {
                Console.WriteLine(c);
            }
        }
        static void GetAllOrders(AppDbContext context) {
            var ords = context.Orders.ToList();
            foreach(var o in ords) {
                Console.WriteLine(o);
            }
        }
        static void GetAllProducts(AppDbContext context) {
            var prods = context.Products.ToList();
            foreach(var p in prods) {
                Console.WriteLine(p);
            }
        }
        static void GetCustomerByPk(AppDbContext context) {
            var custpk = 5;
            var cust = context.Customers.Find(custpk);
            if (cust == null) throw new Exception("Customer not found");
            Console.WriteLine(cust);
        }
        static void GetOrderlines(AppDbContext context) {
            var orderlines = context.Orderlines.ToList();
            orderlines.ForEach(line => Console.WriteLine($"{line.Quantity}/{line.Orderx.Description}/{line.Productx.Name}"));
        }
        static void UpdateCustomerSales(AppDbContext context) {
            var custOrderJoin = from c in context.Customers
                                join o in context.Orders
                                on c.Id equals o.CustomerId
                                where c.Id == 3
                                select new { Amount = o.Amount, Customer = c.Name, Order = o.Description};
            var ordertotal = custOrderJoin.Sum(c => c.Amount);
            var cust = context.Customers.Find(5);
            cust.Sales = ordertotal;
            context.SaveChanges();
        }
        static void UpdateCustomer(AppDbContext context) {
            var custpk = 2;
            var cust = context.Customers.Find(custpk);
            if (cust == null) throw new Exception("Customer not found");
            cust.Sales = 191295151621;
            var rowsAffexted = context.SaveChanges();
            if (rowsAffexted != 1) throw new Exception("Failed to Update");
            Console.WriteLine("Update Successful");
        }
        static void UpdateProduct(AppDbContext context) {
            var prodpk = 1;
            var prod = context.Orders.Find(prodpk); {
                if (prod == null) throw new Exception("Order not found");
                prod.Amount = 120;
                var rowsAffected = context.SaveChanges();
                if (rowsAffected != 1) throw new Exception("Failed to update");
                Console.WriteLine("Update Successful");
            }
        }
        static void DeleteCustomer(AppDbContext context) {
            var keytodelete = 3;
            var custtodelete = context.Customers.Find(keytodelete);
            if (custtodelete == null) throw new Exception("Not found");
            context.Customers.Remove(custtodelete);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Delete failed");
        }
        static void DeleteOrder(AppDbContext context) {
            var keyToDelete = 6;
            var orderToDelete = context.Orders.Find(keyToDelete);
            if (orderToDelete == null) throw new Exception("Order not Found");
            context.Orders.Remove(orderToDelete);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Delete Failed");
        }


    }
}
