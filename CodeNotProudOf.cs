//In this class, I demonstrate past bad practices such as poor variable naming, excessive if-else nesting, lack of try-catch blocks, 
//absence of dependency injection, and code repetition across methods, code not unit testable. 

using System;

public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Poor variable naming and excessive if-else statements
        decimal cost = 0;
        // Null checks missing
        if (order.Quantity != null)
        {
            if (decimal.TryParse(order.Quantity.ToString(), out decimal quantity))
            {
                if (order.UnitPrice != null)
                {
                    if (decimal.TryParse(order.UnitPrice.ToString(), out decimal unitPrice))
                    {
                        // Repeating logic from other methods
                        cost = quantity * unitPrice + (quantity * 2.0m);
                        Console.WriteLine("Total cost: $" + cost);
                    }
                    else
                    {
                        Console.WriteLine("Invalid unit price.");
                    }
                }
                else
                {
                    Console.WriteLine("Unit price is missing.");
                }
            }
            else
            {
                Console.WriteLine("Invalid quantity.");
            }
        }
        else
        {
            Console.WriteLine("Quantity is missing.");
        }
    }
}

public class Order
{
    public object Quantity { get; set; }
    public object UnitPrice { get; set; }
}
