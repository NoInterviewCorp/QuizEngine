using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asp_back.hubs;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Learners.Services {
    public class QueueHandler : IDisposable {
        private List<string> Ids;
        private static ConnectionFactory factory;
        private static IConnection connection;
        public IModel model;
        private readonly IHubContext<TestHub> hubContext;
        private const string ExchangeNme = "KnowledgeExchange";
        public QueueHandler (IHubContext<TestHub> _hubcontext) {
            factory = new ConnectionFactory {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                DispatchConsumersAsync = true
            };
            hubContext = _hubcontext;
            connection = factory.CreateConnection ();
            model = connection.CreateModel ();
        }
        public void Dispose () {
            connection.Close ();
        }
        public async Task QuestionBatchResponseHandler () {
            var channel = connection.CreateModel ();
            var consumer = new AsyncEventingBasicConsumer (channel);
            consumer.Received += async (model, ea) => {
                Console.WriteLine ("Recieved Questions");
                var body = ea.Body;
                channel.BasicAck (ea.DeliveryTag, false);
                var routingKey = ea.RoutingKey;
                Console.WriteLine (" - Routing Key <{0}>", routingKey);
                Console.WriteLine ("- Delivery Tag <{0}>", ea.DeliveryTag);
                await Task.Yield ();
            };
            channel.BasicConsume ("QuizEngine_KnowledgeGraph", false, consumer);
            // await hubContext.Clients.Client
        }
    }
}