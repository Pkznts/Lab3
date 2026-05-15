using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services.Discounts;

public class NoDiscountPolicy : IDiscountPolicy
{
    public string Name => "Без скидки";

    public decimal CalculateDiscount(Order order)
    {
        return 0;
    }
}
