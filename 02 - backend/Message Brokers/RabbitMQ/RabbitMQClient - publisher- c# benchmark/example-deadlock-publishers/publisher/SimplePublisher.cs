using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace publisher
{
    public static class SimplePublisher
    {

        public static async Task Publish(string queue, string message)
        {
            Console.WriteLine("starting...");
            // await Task.Yield();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Console.WriteLine("creating connection...");
            var connection = factory.CreateConnection();
            Console.WriteLine("creating model...");
            var channel = connection.CreateModel();
            Console.WriteLine("declaring queue...");

            channel.QueueDeclare(queue: queue,
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            Console.WriteLine("queue declared");
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                routingKey: queue,
                                basicProperties: null,
                                body: body);
            Console.WriteLine("done");
        }
    }
}
