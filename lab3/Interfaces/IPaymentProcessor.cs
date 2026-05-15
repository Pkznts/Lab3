using Lab3.Models;

namespace Lab3.Interfaces;

public interface IPaymentProcessor
{
    string Name { get; }

    bool Pay(Order order, decimal amount);
}
