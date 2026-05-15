using Lab3.Interfaces;
using Lab3.Models;
using Lab3.Services;
using Lab3.Services.Discounts;
using Lab3.Services.Notifications;
using Lab3.Services.Payments;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Лабораторная работа №3. Задание №1");
Console.WriteLine("Вариант №1: система оформления заказа");
Console.WriteLine();

Customer customer = new("Иван Петров", "ivan@example.com", "+7-900-111-22-33");
Product laptop = new("Ноутбук", 75_000m, 5);
Product mouse = new("Мышь", 2_500m, 20);

Order order = new(customer);
order.AddItem(laptop, 1);
order.AddItem(mouse, 2);

IOrderValidator validator = new OrderValidator();

RunScenario(
    "Сценарий 1: заказ без скидки, оплата картой, уведомление по Email",
    order,
    new NoDiscountPolicy(),
    new CardPaymentProcessor(),
    new EmailNotificationSender(),
    validator);

RunScenario(
    "Сценарий 2: процентная скидка, банковский перевод, уведомление по SMS",
    order,
    new PercentageDiscountPolicy(10),
    new BankTransferPaymentProcessor(),
    new SmsNotificationSender(),
    validator);

ShowInvalidInputScenario(customer, validator);
ShowSolidExplanation();

static void RunScenario(
    string title,
    Order order,
    IDiscountPolicy discountPolicy,
    IPaymentProcessor paymentProcessor,
    INotificationSender notificationSender,
    IOrderValidator validator)
{
    Console.WriteLine(title);
    Console.WriteLine($"Скидка: {discountPolicy.Name}");
    Console.WriteLine($"Оплата: {paymentProcessor.Name}");
    Console.WriteLine($"Уведомление: {notificationSender.Name}");

    OrderService orderService = new(discountPolicy, paymentProcessor, notificationSender, validator);
    OrderResult result = orderService.PlaceOrder(order);

    Console.WriteLine($"Сумма до скидки: {result.TotalBeforeDiscount:C}");
    Console.WriteLine($"Размер скидки: {result.DiscountAmount:C}");
    Console.WriteLine($"Итого к оплате: {result.TotalToPay:C}");
    Console.WriteLine();
}

static void ShowInvalidInputScenario(Customer customer, IOrderValidator validator)
{
    Console.WriteLine("Сценарий 3: обработка некорректных входных данных");

    try
    {
        Product keyboard = new("Клавиатура", 4_000m, 1);
        Order invalidOrder = new(customer);
        invalidOrder.AddItem(keyboard, 3);

        OrderService orderService = new(
            new PercentageDiscountPolicy(5),
            new CardPaymentProcessor(),
            new EmailNotificationSender(),
            validator);

        orderService.PlaceOrder(invalidOrder);
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Ошибка: {exception.Message}");
    }

    Console.WriteLine();
}

static void ShowSolidExplanation()
{
    Console.WriteLine("Где показаны принципы SOLID:");
    Console.WriteLine("SRP: Product, OrderItem, Order хранят доменные данные; OrderValidator проверяет заказ; OrderService оформляет заказ.");
    Console.WriteLine("OCP: новые скидки, способы оплаты и уведомления добавляются новыми классами без изменения OrderService.");
    Console.WriteLine("LSP: CardPaymentProcessor и BankTransferPaymentProcessor взаимозаменяемы через IPaymentProcessor.");
    Console.WriteLine("ISP: IDiscountPolicy, IPaymentProcessor, INotificationSender и IOrderValidator маленькие и специализированные.");
    Console.WriteLine("DIP: OrderService зависит от интерфейсов и получает зависимости через конструктор.");
}
