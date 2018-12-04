using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.Persistence;
using Evaluation_BackEnd.StaticData;
using Learners.Services;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace asp_back.hubs {
    public class TestHub : Hub {
        private ITestMethods methods;
        private TemporaryData temp;
        public TestHub (ITestMethods _methods) {
            this.methods = _methods;
        }
        // public async Task newMessage (string username, string value) {
        //     await Clients.All.SendAsync ("messageReceived", username, value);
        // }
        public async Task RequestConcepts (string username, string technology) {
            methods.RequestConceptFromTechnology (username, technology);
            await Clients.Caller.SendAsync ("Request For Concept Recieved");
        }
        public async Task OnStart (string username, string tech, List<string> concepts) {
            temp = new TemporaryData (tech, concepts);
            methods.OnStart (temp, username);
            methods.GetQuestionsBatch (username, tech, concepts);
            await Clients.Caller.SendAsync ("Temporary Object Created");
        }
        public async Task OnFinish () {
            await Clients.Caller.SendAsync ("Data Seeded");
        }
        // public async Task CountQuizAttempts (string tech, string username) {
        //     bool AttemptedEarlier = false;
        //     AttemptedEarlier = methods.CountQuizAttempts (tech, username);
        //     await Clients.Caller.SendAsync ("Got the Response", AttemptedEarlier);
        // }
        public async Task EvaluateAnswer (string Username, string QuestionId, string OptionId) {
            methods.EvaluateAnswer(Username, QuestionId,OptionId);
            await Clients.Caller.SendAsync ("Evaluating Answer");
        }
        public async Task GetQuestionsBatch (string username, string tech, List<string> concept) {
            methods.GetQuestionsBatch (username, tech, concept);
            await Clients.Caller.SendAsync ("Recieved Request for Questions");
        }
        public override async Task OnConnectedAsync () 
        {
            var httpContext = Context.GetHttpContext ();
            var username = httpContext.Request.Query["username"].ToString ();
            ConnectionData.userconnectiondata.Add (username, Context.ConnectionId);
            await base.OnConnectedAsync ();
        }

        public override async Task OnDisconnectedAsync (Exception exception) 
        {
            await base.OnDisconnectedAsync (exception);
        }

    }
}