using Lab3.Models;

namespace Lab3.Interfaces;

public interface IDiscountPolicy
{
    string Name { get; }

    decimal CalculateDiscount(Order order);
}
