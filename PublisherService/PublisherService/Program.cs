using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "message_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

    string message = "Hello, Nghia";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "", routingKey: "message_queue", basicProperties: null, body: body);

    Console.WriteLine($" [x] Sent '{message}'");
}

Console.WriteLine("Press [Enter] to exit.");
Console.ReadLine();