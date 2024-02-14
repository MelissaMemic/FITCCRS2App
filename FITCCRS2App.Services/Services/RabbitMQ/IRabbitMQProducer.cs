namespace FITCCRS2App.Services.Services.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendMessage<T>(T message);
    }
}

