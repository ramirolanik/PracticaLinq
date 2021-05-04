using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLinq
{
    class Program
    {

        static void Main(string[] args)
        {
            Model1 contexto;
            contexto = new Model1();


            List<Customers> GetCustomers()
            {
                var listCustomers = (from CustomerID in contexto.Customers
                                     select CustomerID).ToList();

                return listCustomers;

            }


            var query = GetCustomers().Where(m => m.CustomerID != null);


            // Punto 1

            Console.WriteLine("1. Query para devolver objeto customer: ");
            foreach (var item in query)
            {
                Console.WriteLine(item.CustomerID + " " + item.CompanyName);
            }


            List<Products> GetProducts()
            {
                var listProducts = (from UnitsInStock in contexto.Products
                                    select UnitsInStock).ToList();

                return listProducts;

            }

            var query2 = GetProducts().Where(p => p.UnitsInStock == 0);

            // Punto 2

            Console.WriteLine("2. Query para devolver todos los productos sin stock: ");
            foreach (var item in query2)

            {
                Console.WriteLine(item.ProductID + " " + item.ProductName);
            }


            // Punto 3

            var query3 = GetProducts().Where(p => p.UnitsInStock > 0 & p.UnitPrice > 3);


            Console.WriteLine("3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad: ");
            foreach (var item in query3)

            {
                Console.WriteLine(item.ProductID + " " + item.ProductName);
            }

            // Punto 4

            //var query4 = GetCustomers().Where(m => m.City=="Washington");
            var query4 = GetCustomers().Where(m => m.City == "Paris"); //Cambie la City por Paris porque Washington no devuelve datos


            Console.WriteLine("4. Query para devolver todos los customers de Washington: ");
            foreach (var item in query4)
            {
                Console.WriteLine(item.CustomerID + " " + item.CompanyName);
            }

            // Punto 5

            var query5 = GetProducts().Where(p => p.ProductID == 789);


            Console.WriteLine("5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            foreach (var item in query5)

            {
                Console.WriteLine(item.ProductID + " " + item.ProductName);
            }

            // Punto 6 

            var query6 = GetCustomers().Where(m => m.CustomerID != null);

                       
            Console.WriteLine("6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.: ");
            foreach (var item in query6)
            {
                Console.WriteLine(item.ContactName.ToUpper () +" " + item.ContactName.ToLower());
            }

            // Punto 7

            List<Orders> GetOrders()
            {
                var listOrders = (from OrderID in contexto.Orders
                                     select OrderID).ToList();

                return listOrders;

            }
            var query7 = from customers in contexto.Customers
                         join orders in contexto.Orders 
                         on new { customers.CustomerID }
                            equals new { orders.CustomerID }
                         select new { customers.CustomerID, orders.OrderDate, customers.City };

            var query8 = query7.Where(m => m.City == "Washington");/// & m.OrderDate > "01/01/1997");


            Console.WriteLine("Query para devolver Join entre Customers y Orders donde los customers sean de Washington y la fecha de orden sea mayor a 1 / 1 / 1997.: ");
            foreach (var item in query8)
            {
                Console.WriteLine(item.CustomerID + " " + item.City);
            }

            Console.ReadLine();
        }
    }
}
