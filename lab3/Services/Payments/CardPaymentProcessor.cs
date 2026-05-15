using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services.Payments;

public class CardPaymentProcessor : IPaymentProcessor
{
    public string Name => "Банковская карта";

    public bool Pay(Order order, decimal amount)
    {
        Console.WriteLine($"Оплата картой: списано {amount:C}.");
        return true;
    }
}
