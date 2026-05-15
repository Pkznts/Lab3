namespace Lab3.Models;

public class OrderResult
{
    public OrderResult(decimal totalBeforeDiscount, decimal discountAmount, decimal totalToPay)
    {
        TotalBeforeDiscount = totalBeforeDiscount;
        DiscountAmount = discountAmount;
        TotalToPay = totalToPay;
    }

    public decimal TotalBeforeDiscount { get; }

    public decimal DiscountAmount { get; }

    public decimal TotalToPay { get; }
}
