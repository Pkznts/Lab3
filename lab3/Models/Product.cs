namespace Lab3.Models;

public class Product
{
    public Product(string name, decimal price, int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Название товара не может быть пустым.", nameof(name));
        }

        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Цена товара должна быть положительной.");
        }

        if (stockQuantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Количество товара на складе не может быть отрицательным.");
        }

        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public string Name { get; }

    public decimal Price { get; }

    public int StockQuantity { get; }

    public bool IsAvailable => StockQuantity > 0;
}
