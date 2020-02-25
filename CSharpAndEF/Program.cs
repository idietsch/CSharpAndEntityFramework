using CSharpAndEFLibrary.Models;
using CSharpAndEntityFramework;
using System;
using System.Linq;

namespace CSharpAndEF {
    class Program {
        static void Main(string[] args) {
            var context = new AppDbContext();
            //AddCustomer(context);
            GetCustomerByPk(context);
            //UpdateCustomer(context);
            //DeleteCustomer(context);
            GetAllCustomers(context);
            //AddOrder(context);
            GetAllOrders(context);
            //UpdateCustomerSales(context);
            //AddProduct(context);
            GetAllProducts(context);
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
        static void GetCustomerByPk(AppDbContext context) {
            var custpk = 5;
            var cust = context.Customers.Find(custpk);
            if (cust == null) throw new Exception("Customer not found");
            Console.WriteLine(cust);
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

        static void AddOrder(AppDbContext context) {
            var ord = new Order {
                Id = 0,
                CustomerId = 5,
                Amount = 3,
                Description = "Tommy Gun",
            };
            context.Orders.Add(ord);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Order Add Failed");
            else { 
            Console.WriteLine("Add Successful");
            }
        }
        //Alternatively
        //static void AddOrder(AppDbContext context) {
        //var order 1 = new Order {Id = 0, Description = "Whateva", Amount = 222, CustomerId = 5, Customer = Bob's Diner;
        //var order 2 = new Order {Id = 0, Description = "Knuckle Sandwich", Amount = 500, CustomerId = 5, Customer = Bob's Diner;
        //var order 3 = new Order {Id = 0, Description = "Dirt Nap", Amount = 1, CustomerId = 5, Customer = Bob's Diner;
        //var order 4 = new Order {Id = 0, Description = "Soda Pop", Amount = 15, CustomerId = 5, Customer = Bob's Diner;
        //var order 5 = new Order {Id = 0, Description = "Tommy Gun", Amount = 7, CustomerId = 5, Customer = Bob's Diner;
        //context.AddRange(order1,order2,order3,order4,order5);
        //var rowsAffected = context.SaveChanges();
        //
        //}

        static void AddCustomer(AppDbContext context) {
            var cust = new Customer {
                Id = 0,
                Name = "Walmart",
                Sales = 10,
                Active = true
            };
            context.Customers.Add(cust);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Customer Add Failed");
            return;

        }

        static void DeleteCustomer(AppDbContext context) {
            var keytodelete = 3;
            var custtodelete = context.Customers.Find(keytodelete);
            if (custtodelete == null) throw new Exception("Not found");
            context.Customers.Remove(custtodelete);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Delete failed");
        }

        static void AddProduct(AppDbContext context) {
            var product1 = new Product { Id = 0, Price = 150, Name = "Shoe", Code = "Le Code" };
            var product2 = new Product { Id = 0, Price = 12, Name = "Egg", Code = "Egg" };
            var product3 = new Product { Id = 0, Price = 12345, Name = "Thing", Code = "Thng" };
            var product4 = new Product { Id = 0, Price = 100, Name = "A Hundred Dollar Bill", Code = "Money" };
            var product5 = new Product { Id = 0, Price = 0, Name = "Free Shit", Code = "Free" };
            context.AddRange(product1, product2, product3, product4, product5);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("fail");
            return;
        }

        static void GetAllProducts(AppDbContext context) {
            var prods = context.Products.ToList();
            foreach(var p in prods) {
                Console.WriteLine(p);
            }
        }


    }
}
