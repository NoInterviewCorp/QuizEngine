using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.Persistence;
using Learners.Services;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace asp_back.hubs {
    public class TestHub : Hub {
        private ITestMethods methods;
        private QueueHandler queuehandler;
        private TemporaryData temp;
        private List<string> concepts;
        private static Dictionary<string, List<TemporaryData>> data;
        public TestHub (ITestMethods _methods, QueueHandler _queuehandler) {
            this.methods = _methods;
            this.queuehandler = _queuehandler;
        }
        public async Task newMessage (string username, string value) {
            await Clients.All.SendAsync ("messageReceived", username, value);
        }
        // public async Task GetAllTechnoligies () {
        //     var tech = methods.GetAllTechnologies ();
        //     await Clients.Caller.SendAsync ("GotAllTechnoligies", tech);
        // }
        public async Task RequestConcepts (string username, string technology) {
            methods.RequestConceptFromTechnology (username, technology);
            List<Question> questions = new List<Question> ();
            var channel = queuehandler.model;
            var consumer = new AsyncEventingBasicConsumer (channel);
            consumer.Received += async (model, ea) => {
                Console.WriteLine ("Recieved Concepts");
                var body = ea.Body;
                questions.Clear ();
                questions.AddRange ((List<Question>) body.DeSerialize (typeof (Question)));
                channel.BasicAck (ea.DeliveryTag, false);
                Console.WriteLine ("- Delivery Tag <{0}>", ea.DeliveryTag);
                await Task.Yield ();
            };
            channel.BasicConsume ("KnowledgeGraphToQuizEngine", false, consumer);
            await Clients.Caller.SendAsync ("GotAllQuestions", questions);
        }
        public async Task OnStart (string username, string tech, List<string> concepts) {
            temp = new TemporaryData (tech, concepts);
            methods.OnStart (temp, username, tech);
            methods.GetQuestionsBatch (username, tech, concepts);
            await Clients.Caller.SendAsync ("Temporary Object Created");
        }
        public async Task OnFinish () {
            await Clients.Caller.SendAsync ("Data Seeded");
        }
        public async Task AttemptedQuizEarlier (string tech, string username) {
            bool AttemptedEarlier = false;
            AttemptedEarlier = methods.CheckQuiz (tech, username);
            await Clients.Caller.SendAsync ("Got the Response", AttemptedEarlier);
        }
        public async Task EvaluateAnswer (string QuestionId, string OptionId) {
            await Clients.Caller.SendAsync ("Answer Evaluated");
        }
        public async Task GetQuestions (string username, string tech, string concept) {
            methods.GetQuestionsBatch (username, tech, concepts);
            await Clients.Caller.SendAsync ("Got Questions");
        }
        public override async Task OnConnectedAsync () {
            await base.OnConnectedAsync ();
        }

        public override async Task OnDisconnectedAsync (Exception exception) {
            await base.OnDisconnectedAsync (exception);
        }
    }
}