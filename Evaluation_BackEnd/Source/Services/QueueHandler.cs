using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asp_back.hubs;
using Evaluation_BackEnd.ContentWrapper;
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
        public void QuestionBatchResponseHandler () {
            var channel = connection.CreateModel ();
            var consumer = new AsyncEventingBasicConsumer (channel);
            consumer.Received += async (model, ea) => {
                Console.WriteLine ("<--------------------Recieved Questions--------------------->");
                var body = ea.Body;
                var data = (QuestionBatchResponse) body.DeSerialize (typeof (QuestionBatchResponse));
                Console.WriteLine (data);
                Console.WriteLine ("<------------------------------------------------------------>");
                channel.BasicAck (ea.DeliveryTag, false);
                var routingKey = ea.RoutingKey;
                Console.WriteLine (" - Routing Key <{0}>", routingKey);
                Console.WriteLine ("- Delivery Tag <{0}>", ea.DeliveryTag);
                // await hubContext.Clients.Client(ConnectionData.userconnectiondata(QuestionBatchResponse.username)).SendAsync("",Data);
                await Task.Yield ();
            };
            channel.BasicConsume ("QuizEngine_KnowledgeGraph", false, consumer);
        }
        public void ConceptResponseHandler () {
            var channel = connection.CreateModel ();
            var consumer = new AsyncEventingBasicConsumer (channel);
            consumer.Received += async (model, ea) => {
                Console.WriteLine ("<--------------------Recieved Questions--------------------->");
                var body = ea.Body;
                var data = (ConceptResponse) body.DeSerialize (typeof (ConceptResponse));
                Console.WriteLine (data);
                Console.WriteLine ("<------------------------------------------------------------>");
                channel.BasicAck (ea.DeliveryTag, false);
                var routingKey = ea.RoutingKey;
                Console.WriteLine (" - Routing Key <{0}>", routingKey);
                Console.WriteLine ("- Delivery Tag <{0}>", ea.DeliveryTag);
                // await hubContext.Clients.Client(ConnectionData.userconnectiondata(ConceptResponse.username)).SendAsync("",Data);
                await Task.Yield ();
            };
            channel.BasicConsume ("QuizEngine_KnowledgeGraph", false, consumer);
        }
    }
}