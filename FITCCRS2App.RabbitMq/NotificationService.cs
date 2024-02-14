using System;
using System.Text;

namespace FITCCRS2App.RabbitMq
{
    public class NotificationService : INotificationService
    {
        private readonly RabbitMQConfiguration RabbitMQConfiguration;
        private readonly ILogger<NotificationService> Logger;

        public NotificationService(
            IOptions<RabbitMQConfiguration> rabbitMQConfiguration,
            ILogger<NotificationService> logger)
        {
            RabbitMQConfiguration = rabbitMQConfiguration.Value;
            Logger = logger;
        }

        public void SendNotification(Notification notification)
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

                var exchangeName = notification.Group.ToString();
                channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);

                channel.BasicPublish(
                    exchange: exchangeName,
                    routingKey: string.Empty,
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(notification.ToJson()));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Send Notification exception");
            }
        }

        public void TakeBreak()
        {
            var notification = new Notification
            {
                Type = NotificationType.Info,
                Group = Role.Employee,
                Text = "Molimo napravite pauzu"
            };

            SendNotification(notification);
        }
    }