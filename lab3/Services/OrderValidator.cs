using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services;

public class OrderValidator : IOrderValidator
{
    public void Validate(Order order)
    {
        if (order.Items.Count == 0)
        {
            throw new InvalidOperationException("Заказ не содержит товаров.");
        }

        foreach (OrderItem item in order.Items)
        {
            if (!item.Product.IsAvailable)
            {
                throw new InvalidOperationException($"Товар '{item.Product.Name}' отсутствует на складе.");
            }

            if (item.Quantity > item.Product.StockQuantity)
            {
                throw new InvalidOperationException(
                    $"Недостаточно товара '{item.Product.Name}' на складе. Доступно: {item.Product.StockQuantity}, запрошено: {item.Quantity}.");
            }
        }
    }
}
