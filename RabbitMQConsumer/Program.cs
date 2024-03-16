using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQConsumer;
using System.Text;
Console.WriteLine($"Application started");

var factory = new ConnectionFactory
{
    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitMQ",
    Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672"),
    UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
    Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
};
Console.WriteLine(Environment.GetEnvironmentVariable("RABBITMQ_HOST"));
Console.WriteLine(Environment.GetEnvironmentVariable("RABBITMQ_PORT"));
Console.WriteLine(Environment.GetEnvironmentVariable("RABBITMQ_USERNAME"));
Console.WriteLine(Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD"));

factory.ClientProvidedName = "Rabbit Test Consumer";
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();
Console.WriteLine($"Application connected");

string exchangeName = "EmailExchange";
string routingKey = "email_queue";
string queueName = "EmailQueue";

channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
channel.QueueDeclare(queueName, true, false, false, null);
channel.QueueBind(queueName, exchangeName, routingKey, null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    //Task.Delay(TimeSpan.FromSeconds(2)).Wait();
    var body = args.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Message received: {message}");
    EmailService emailService = new EmailService();
    emailService.SendEmail(message);

    channel.BasicAck(args.DeliveryTag, false);
};

channel.BasicConsume(queueName, false, consumer);

Console.WriteLine("Waiting for messages. Press Q to quit.");

Thread.Sleep(Timeout.Infinite);

channel.Close();
connection.Close();

