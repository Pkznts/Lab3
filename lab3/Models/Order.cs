namespace Lab3.Models;

public class Order
{
    private readonly List<OrderItem> _items = new();

    public Order(Customer customer)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
    }

    public Customer Customer { get; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public void AddItem(Product product, int quantity)
    {
        _items.Add(new OrderItem(product, quantity));
    }

    public decimal TotalBeforeDiscount => _items.Sum(item => item.TotalPrice);
}
