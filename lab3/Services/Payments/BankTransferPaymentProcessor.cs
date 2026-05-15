using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services.Payments;

public class BankTransferPaymentProcessor : IPaymentProcessor
{
    public string Name => "Банковский перевод";

    public bool Pay(Order order, decimal amount)
    {
        Console.WriteLine($"Оплата банковским переводом: выставлен счет на {amount:C}.");
        return true;
    }
}
