using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services.Notifications;

public class SmsNotificationSender : INotificationSender
{
    public string Name => "SMS";

    public void Send(Customer customer, string message)
    {
        Console.WriteLine($"SMS для {customer.Phone}: {message}");
    }
}
