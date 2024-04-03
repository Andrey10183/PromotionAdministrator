using Comandante.Application.Interfaces;
using System.Net.Http.Json;

namespace Comandante.Infrastructure.Services;

internal class EmailService : IEmailService
{
    private readonly HttpClient _httpClient;

    public EmailService(IHttpClientFactory httpFactory)
    {
        _httpClient = httpFactory.CreateClient("MailService");
    }

    public async Task<bool> SendPasswordReminder(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || 
            string.IsNullOrEmpty(password))
        {
            return false;
        }

        var request = new
        {
            Subject = "Пароль от сервиса Comandante",
            Body = $"Пароль от сервиса Comandante: {password}",
            IsBodyContentsOfHtmlType = true,
            Recipients = new string[] {email},
            IsError = 0
        };

        var response = await _httpClient.PostAsJsonAsync("Sender/PostMail", request);

        return response.IsSuccessStatusCode;
    }
}
