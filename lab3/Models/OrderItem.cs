namespace Lab3.Models;

public class OrderItem
{
    public OrderItem(Product product, int quantity)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Количество товара в заказе должно быть положительным.");
        }

        Quantity = quantity;
    }

    public Product Product { get; }

    public int Quantity { get; }

    public decimal TotalPrice => Product.Price * Quantity;
}
