# Лабораторная работа №3. Задание №1

Вариант: система оформления заказа.

## Предметная модель

- `Customer` — покупатель.
- `Product` — товар.
- `OrderItem` — позиция заказа.
- `Order` — заказ покупателя.

## Интерфейсы

- `IDiscountPolicy` — алгоритм расчета скидки.
- `IPaymentProcessor` — способ оплаты.
- `INotificationSender` — способ отправки уведомления.
- `IOrderValidator` — проверка корректности заказа.

## Реализации

- Скидки: `NoDiscountPolicy`, `PercentageDiscountPolicy`.
- Оплата: `CardPaymentProcessor`, `BankTransferPaymentProcessor`.
- Уведомления: `EmailNotificationSender`, `SmsNotificationSender`.

## Демонстрация SOLID

- SRP: `Product`, `OrderItem`, `Order` отвечают за доменные данные, `OrderValidator` — за проверку заказа, `OrderService` — за оформление заказа.
- OCP: новую скидку, оплату или уведомление можно добавить новым классом, не меняя `OrderService`.
- LSP: `CardPaymentProcessor` и `BankTransferPaymentProcessor` можно подставлять вместо `IPaymentProcessor`, и `OrderService` продолжит работать корректно.
- ISP: интерфейсы маленькие и специализированные, реализации не обязаны оставлять методы пустыми или бросать `NotSupportedException`.
- DIP: `OrderService` зависит от абстракций и получает их через конструктор.
