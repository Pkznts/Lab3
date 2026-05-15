using Lab3.Models;

namespace Lab3.Interfaces;

public interface INotificationSender
{
    string Name { get; }

    void Send(Customer customer, string message);
}
