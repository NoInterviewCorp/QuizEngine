using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_back.hubs;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.RabbitMQModels;
using Evaluation_BackEnd.StaticData;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Evaluation_BackEnd.Persistence;
namespace Learners.Services
{
    public class QueueHandler : IDisposable
    {
        private static ConnectionFactory factory;
        private static IConnection connection { get; set; }
        public IModel Model { get; set; }
        public readonly IHubContext<TestHub> hubContext;
        private const string ExchangeName = "KnowledgeGraphExchange";
        public QueueHandler(IHubContext<TestHub> _hubcontext)
        {
            factory = new ConnectionFactory
            {
                HostName = "172.23.238.173",
                UserName = "achausername",
                Password = "strongpassword",
                DispatchConsumersAsync = true
            };
            hubContext = _hubcontext;
            connection = factory.CreateConnection();
            this.Model = connection.CreateModel();
            this.QuestionBatchResponseHandler();
        }
        public void Dispose()
        {
            connection.Close();
        }
        public void StartTimer(string Username)
        {
            Console.WriteLine("---Timer Started---");
            var timer = new System.Threading.Timer(OnFinish, Username, 30000, -1);
        }
        public async void OnFinish(Object Username)
        {
            var username = (string)Username;
            Console.WriteLine(username);
            if (TemporaryQuizData.TemporaryUserData.ContainsKey(username))
            {
                var tempdata = TemporaryQuizData.TemporaryUserData[username];
                QuizData quiz = new QuizData(tempdata);
                UserData userdata = new UserData(username,quiz);
                Model.BasicPublish(exchange: "KnowledgeGraphExchange",
                    routingKey: "User.QuizData",
                    basicProperties: null,
                    body: userdata.Serialize());
                TemporaryQuizData.TemporaryUserData.Remove(username);
                await hubContext.Clients.Client(ConnectionData.userconnectiondata[username]).SendAsync("Quiz Over", userdata);
            }
        }
        public void QuestionBatchResponseHandler()
        {
            var channel = connection.CreateModel();
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                try
                {
                    Console.WriteLine("<--------------------Recieved Questions--------------------->");
                    channel.BasicAck(ea.DeliveryTag, false);
                    var body = ea.Body;
                    var data = (QuestionBatchResponse)body.DeSerialize(typeof(QuestionBatchResponse));
                    Console.WriteLine(data);
                    Console.WriteLine(data.Username);
                    Console.WriteLine(data.ResponseList.Count());
                    if(data.ResponseList.Count()<1)
                    {
                        Console.WriteLine("no questions found in database");
                        await Task.Yield();
                    }
                    TemporaryQuizData.TemporaryUserData[data.Username].QuestionsAttempted.AddRange(data.ResponseList);
                    StartTimer(data.Username);
                    foreach (var v in data.ResponseList)
                    {
                        Console.WriteLine(v.ProblemStatement);
                    }
                    Console.WriteLine(TemporaryQuizData.TemporaryUserData[data.Username].QuestionsAttempted);
                    Console.WriteLine("<------------------------------------------------------------>");
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine(" - Routing Key <{0}>", routingKey);
                    Console.WriteLine("- Delivery Tag <{0}>", ea.DeliveryTag);
                    Console.WriteLine(ConnectionData.userconnectiondata[data.Username]);
                    await hubContext.Clients.Client(ConnectionData.userconnectiondata[data.Username]).SendAsync("GetQuestion", data.ResponseList,data.ResponseList.Count());
                    await Task.Yield();
                }
                catch (Exception e)
                {
                    Console.WriteLine("----------------------EXCEPTION-MESSAGE------------------------------------");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("----------------------STACK-TRACE-----------------------------------------");
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("-------------------------INNER-EXCEPTION-----------------------------");
                    Console.WriteLine(e.InnerException);
                    // return null;
                }
            };
            channel.BasicConsume("Contributer_QuizEngine_Questions", false, consumer);
        }
        public void RecommendedResourceResponseHnadler()
        {
            var channel = connection.CreateModel();
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                try
                {
                    Console.WriteLine("<--------------------Recieved Questions--------------------->");
                    channel.BasicAck(ea.DeliveryTag, false);
                    var body = ea.Body;
                    var data = (ResourceResponse)body.DeSerialize(typeof(ResourceResponse));
                    Console.WriteLine(data);
                    Console.WriteLine(data.Username);
                    Console.WriteLine("Got Recommended Resources from Queue");
                    Console.WriteLine("<------------------------------------------------------------>");
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine(" - Routing Key <{0}>", routingKey);
                    Console.WriteLine("- Delivery Tag <{0}>", ea.DeliveryTag);
                    Console.WriteLine(ConnectionData.userconnectiondata[data.Username]);
                    await hubContext.Clients.Client(ConnectionData.userconnectiondata[data.Username]).SendAsync("GetResources",data.Resources);
                    await Task.Yield();
                }
                catch (Exception e)
                {
                    Console.WriteLine("----------------------EXCEPTION-MESSAGE------------------------------------");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("----------------------STACK-TRACE-----------------------------------------");
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("-------------------------INNER-EXCEPTION-----------------------------");
                    Console.WriteLine(e.InnerException);
                    // return null;
                }
            };
            channel.BasicConsume("Contributer_QuizEngine_Reource", false, consumer);
        }
    }
}