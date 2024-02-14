namespace FITCCRS2App.Services.Services.RabbitMQ;
public interface IEmailService
{
    Task SendErrorMailAsync(string message);
}