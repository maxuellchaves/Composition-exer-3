using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composition_obj_exer_3.Entities;
using Composition_obj_exer_3.Entities.Enums;
using System.Globalization;

namespace Composition_obj_exer_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            Enum.TryParse(Console.ReadLine(), out OrderStatus status);

            Client c1 = new Client(name, email, date);
            Order order = new Order(DateTime.Now, status, c1);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            
            Console.WriteLine();
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                 name = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product p1 = new Product(name, price);

                OrderItem item = new OrderItem(quantity, price, p1);

               

                order.AddItem(item);
                Console.WriteLine();

            }

            Console.WriteLine("Order SUMMARY: ");
            Console.WriteLine(order);



        }
    }
}
