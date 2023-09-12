using System;

public class OrderProcessor
{
    private readonly IShippingService _shippingService;

    public OrderProcessor(IShippingService shippingService)
    {
        _shippingService = shippingService;
    }

    public void ProcessOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        // Improved variable naming and no excessive if-else statements
        decimal shippingCost = _shippingService.CalculateShippingCost(order);

        // Proper try-catch block for potential exceptions during conversion
        try
        {
            int quantity = Convert.ToInt32(order.Quantity);
            decimal totalCost = quantity * order.UnitPrice + shippingCost;
            Console.WriteLine($"Total cost: ${totalCost}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

public interface IShippingService
{
    decimal CalculateShippingCost(Order order);
}

public class Order
{
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class ShippingService : IShippingService
{
    public decimal CalculateShippingCost(Order order)
    {
        // Shipping cost calculation logic here
        return order.Quantity * 2.0m;
    }
}
