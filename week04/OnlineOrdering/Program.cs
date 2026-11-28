using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Customer usaCustomer = new Customer(
            "Sarah Johnson",
            new Address("123 Maple Street", "Provo", "Utah", "USA"));
        Order usaOrder = new Order(usaCustomer);
        usaOrder.AddProduct(new Product("Notebook", "NB-101", 3.50m, 2));
        usaOrder.AddProduct(new Product("Blue Pen", "PN-204", 1.25m, 4));
        usaOrder.AddProduct(new Product("Backpack", "BP-330", 24.99m, 1));

        Customer internationalCustomer = new Customer(
            "Daniel Okafor",
            new Address("18 Palm Avenue", "Lagos", "Lagos State", "Nigeria"));
        Order internationalOrder = new Order(internationalCustomer);
        internationalOrder.AddProduct(new Product("Water Bottle", "WB-410", 12.00m, 2));
        internationalOrder.AddProduct(new Product("Sketchbook", "SK-512", 8.75m, 1));

        List<Order> orders = new List<Order> { usaOrder, internationalOrder };

        Console.WriteLine("ONLINE ORDERING PROGRAM\n");
        for (int i = 0; i < orders.Count; i++)
        {
            Order order = orders[i];
            Console.WriteLine($"ORDER {i + 1}");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total cost: ${order.GetTotalCost():F2}");
            if (i < orders.Count - 1)
                Console.WriteLine("\n------------------------------\n");
        }
    }
}
