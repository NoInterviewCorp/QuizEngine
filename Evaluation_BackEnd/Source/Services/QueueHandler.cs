using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asp_back.hubs;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.RabbitMQModels;
using Evaluation_BackEnd.StaticData;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace Learners.Services {
    public class QueueHandler : IDisposable {
        private static ConnectionFactory factory;
        private static IConnection connection { get; set; }
        public IModel Model { get; set; }
        private readonly IHubContext<TestHub> hubContext;
        private const string ExchangeName = "KnowledgeGraphExchange";
        public QueueHandler (IHubContext<TestHub> _hubcontext) {
            factory = new ConnectionFactory {
                HostName = "172.23.238.173",
                UserName = "achausername",
                Password = "strongpassword",
                DispatchConsumersAsync = true
            };
            hubContext = _hubcontext;
            connection = factory.CreateConnection ();
            this.Model = connection.CreateModel ();
            this.QuestionBatchResponseHandler ();
        }
        public void Dispose () {
            connection.Close ();
        }
        public void QuestionBatchResponseHandler () {
            var channel = connection.CreateModel ();
            var consumer = new AsyncEventingBasicConsumer (channel);
            consumer.Received += async (model, ea) => {
                try {
                    Console.WriteLine ("<--------------------Recieved Questions--------------------->");
                    channel.BasicAck (ea.DeliveryTag, false);
                    var body = ea.Body;
                    var data = (QuestionBatchResponse) body.DeSerialize (typeof (QuestionBatchResponse));
                    foreach (KeyValuePair<string, List<Question>> entry in data.ResponseDictionary) {
                        if (TemporaryQuizData.data.ContainsKey (data.Username)) {
                            TemporaryQuizData.data[data.Username].QuestionsAttempted[entry.Key].AddRange (data.ResponseDictionary[entry.Key]);
                        }
                    }
                    Console.WriteLine (data);
                    Console.WriteLine ("<------------------------------------------------------------>");
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine (" - Routing Key <{0}>", routingKey);
                    Console.WriteLine ("- Delivery Tag <{0}>", ea.DeliveryTag);
                    await hubContext.Clients.Client (ConnectionData.userconnectiondata[data.Username]).SendAsync ("", data.ResponseDictionary.Values);
                    await Task.Yield ();
                } catch (Exception e) {
                    Console.WriteLine ("----------------------EXCEPTION-MESSAGE------------------------------------");
                    Console.WriteLine (e.Message);
                    Console.WriteLine ("----------------------STACK-TRACE-----------------------------------------");
                    Console.WriteLine (e.StackTrace);
                    Console.WriteLine ("-------------------------INNER-EXCEPTION-----------------------------");
                    Console.WriteLine (e.InnerException);
                    // return null;
                }
            };
            channel.BasicConsume ("Contributer_QuizEngine_Questions", false, consumer);
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
                await hubContext.Clients.Client (ConnectionData.userconnectiondata[key : data.username]).SendAsync ("", data.concepts);
                await Task.Yield ();
            };
            channel.BasicConsume ("QuizEngine_KnowledgeGraph", false, consumer);
        }
    }
}