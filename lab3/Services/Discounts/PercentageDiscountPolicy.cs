using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services.Discounts;

public class PercentageDiscountPolicy : IDiscountPolicy
{
    private readonly decimal _percent;

    public PercentageDiscountPolicy(decimal percent)
    {
        if (percent < 0 || percent > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(percent), "Процент скидки должен быть от 0 до 100.");
        }

        _percent = percent;
    }

    public string Name => $"Процентная скидка {_percent}%";

    public decimal CalculateDiscount(Order order)
    {
        return order.TotalBeforeDiscount * _percent / 100;
    }
}
