using Lab3.Models;

namespace Lab3.Interfaces;

public interface IOrderValidator
{
    void Validate(Order order);
}
