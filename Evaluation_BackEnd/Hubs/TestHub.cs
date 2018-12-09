using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.Persistence;
using Evaluation_BackEnd.StaticData;
using Learners.Services;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace asp_back.hubs
{
    public class TestHub : Hub
    {
        private ITestMethods methods;
        private TemporaryData temp;
        public TestHub(ITestMethods _methods)
        {
            this.methods = _methods;
        }
        // public async Task newMessage (string username, string value) {
        //     await Clients.All.SendAsync ("messageReceived", username, value);
        // }
        public async Task OnStart(string username, string tech, List<string> concepts)
        {
            temp = new TemporaryData(tech, concepts);
            methods.OnStart(temp, username);
            methods.GetQuestionsBatch(username, tech, concepts);
            await Clients.Caller.SendAsync("Temporary Object Created");
        }
        public async Task EndQuiz(string username)
        {
            methods.EndQuiz(username);
            await Task.Yield();
        }
        public async Task EvaluateAnswer(string Username, string QuestionId, int OptionId)
        {
            await methods.EvaluateAnswer(Username, QuestionId, OptionId);
            await Clients.Caller.SendAsync("Evaluating Answer");
        }
        public async Task GetQuestionsBatch(string username, string tech, List<string> concepts)
        {
            temp = new TemporaryData(tech, concepts);
            methods.OnStart(temp, username);
            Console.WriteLine("Recieved request for questions");
            methods.GetQuestionsBatch(username, tech, concepts);
            await Clients.Caller.SendAsync("ReceivedRequest");
        }
        public async Task RecommendResource(string username)
        {
            methods.RecommendResource(username);
            Console.WriteLine("recommend Resource Called");
            await Clients.Caller.SendAsync("Resource Request Recieved");
        }
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var username = httpContext.Request.Query["username"].ToString();
            Console.WriteLine(username);
            Console.WriteLine(Context.ConnectionId);
            var ConnectionId = Context.ConnectionId;
            if (!(ConnectionData.userconnectiondata.TryAdd(username, ConnectionId)))
            {
                ConnectionData.userconnectiondata.Remove(username);
                ConnectionData.userconnectiondata.Add(username, ConnectionId);
            }
            Console.WriteLine(ConnectionData.userconnectiondata[username]);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (ConnectionData.userconnectiondata.ContainsValue(Context.ConnectionId))
            {
                var user = ConnectionData.userconnectiondata.First(kvp => kvp.Value == Context.ConnectionId);
                ConnectionData.userconnectiondata.Remove(user.Key);
                TemporaryQuizData.TemporaryUserData.Remove(user.Key);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}   