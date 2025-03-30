using System;

// Again I used ChatGPT to come up with addresses, customer names, and products.
class Program
{
    static void Main(string[] args)
    {
        // Address and Customer 1 (USA)
        Address address1 = new Address("123 Center Court", "Orlando", "FL", "USA");
        Customer customer1 = new Customer("Serena Williams", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Tennis Racket", "TR123", 120.0, 1));
        order1.AddProduct(new Product("Wristband Set", "WB456", 15.0, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        // Address and Customer 2 (International)
        Address address2 = new Address("89 Grass Lane", "London", "England", "UK");
        Customer customer2 = new Customer("Andy Murray", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Grass Court Shoes", "SH789", 95.0, 1));
        order2.AddProduct(new Product("Headband", "HB321", 12.5, 1));
        order2.AddProduct(new Product("Grip Tape", "GT654", 6.0, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}\n");
    }
}
