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
            AddOrder(context);
            GetAllOrders(context);
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
            Console.WriteLine("Add Successful");
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
            if (rowsAffected == 0) throw new Exception("Add Failed");
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




    }
}
