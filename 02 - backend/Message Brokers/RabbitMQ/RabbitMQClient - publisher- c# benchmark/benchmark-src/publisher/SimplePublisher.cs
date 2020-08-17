using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace publisher
{
    public static class SimplePublisher
    {

        public static IConnection connection = (new ConnectionFactory() { HostName = "localhost" }).CreateConnection();

        public static async Task Publish(string queue, string message)
        {
            Console.WriteLine("yielding");
            // await Task.Yield();
            // var factory = new ConnectionFactory() { HostName = "localhost" };
            // Console.WriteLine("conecting...");
            // var connection = factory.CreateConnection();
            // Console.WriteLine("connected");
            var channel = connection.CreateModel();
            Console.WriteLine("model");

            channel.QueueDeclare(queue: queue,
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            Console.WriteLine("declared");
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                routingKey: queue,
                                basicProperties: null,
                                body: body);
            Console.WriteLine("ok");
        }
    }
}
