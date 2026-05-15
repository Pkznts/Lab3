using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services.Notifications;

public class EmailNotificationSender : INotificationSender
{
    public string Name => "Email";

    public void Send(Customer customer, string message)
    {
        Console.WriteLine($"Email для {customer.Email}: {message}");
    }
}
