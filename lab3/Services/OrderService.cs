using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services;

public class OrderService
{
    private readonly IDiscountPolicy _discountPolicy;
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly INotificationSender _notificationSender;
    private readonly IOrderValidator _orderValidator;

    public OrderService(
        IDiscountPolicy discountPolicy,
        IPaymentProcessor paymentProcessor,
        INotificationSender notificationSender,
        IOrderValidator orderValidator)
    {
        _discountPolicy = discountPolicy ?? throw new ArgumentNullException(nameof(discountPolicy));
        _paymentProcessor = paymentProcessor ?? throw new ArgumentNullException(nameof(paymentProcessor));
        _notificationSender = notificationSender ?? throw new ArgumentNullException(nameof(notificationSender));
        _orderValidator = orderValidator ?? throw new ArgumentNullException(nameof(orderValidator));
    }

    public OrderResult PlaceOrder(Order order)
    {
        _orderValidator.Validate(order);

        decimal totalBeforeDiscount = order.TotalBeforeDiscount;
        decimal discountAmount = _discountPolicy.CalculateDiscount(order);
        decimal totalToPay = totalBeforeDiscount - discountAmount;

        if (totalToPay < 0)
        {
            throw new InvalidOperationException("Итоговая сумма заказа не может быть отрицательной.");
        }

        bool paymentCompleted = _paymentProcessor.Pay(order, totalToPay);

        if (!paymentCompleted)
        {
            throw new InvalidOperationException("Оплата заказа не была выполнена.");
        }

        _notificationSender.Send(
            order.Customer,
            $"Заказ оформлен. Сумма к оплате: {totalToPay:C}. Скидка: {discountAmount:C}.");

        return new OrderResult(totalBeforeDiscount, discountAmount, totalToPay);
    }
}
