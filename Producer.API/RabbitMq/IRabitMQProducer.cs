namespace Producer.API.RabbitMq
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
