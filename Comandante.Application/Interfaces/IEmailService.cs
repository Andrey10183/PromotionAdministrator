namespace Comandante.Application.Interfaces;

public interface IEmailService
{
    Task<bool> SendPasswordReminder(string? email, string? password);
}
