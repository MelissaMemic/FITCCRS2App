using System.Text;
using FITCCRS2App.Models.Configurations;
using FITCCRS2App.Services.Services.RabbitMQ;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace FITCCRS2App.RabbitMq
{
    public class EmailService : IEmailService
    {
        private readonly RabbitMQConfiguration RabbitMQConfiguration;
        private readonly ILogger<EmailService> Logger;

        public EmailService(
            IOptions<RabbitMQConfiguration> rabbitMQConfiguration,
            ILogger<EmailService> logger)
        {
            RabbitMQConfiguration = rabbitMQConfiguration.Value;
            Logger = logger;
        }

        public Task SendErrorMailAsync(string message)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = RabbitMQConfiguration.Host,
                    Port = RabbitMQConfiguration.Port,
                    UserName = RabbitMQConfiguration.User,
                    Password = RabbitMQConfiguration.Password
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.ExchangeDeclare("Email", ExchangeType.Fanout);

                channel.BasicPublish(
                    exchange: "Email",
                    routingKey: string.Empty,
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(message)
                );
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "SendErrorMailAsync");
            }

            return Task.CompletedTask;
        }

    }
}
