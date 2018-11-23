using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.Persistence;
using Learners.Services;
using Microsoft.AspNetCore.SignalR;

namespace asp_back.hubs {
    public class TestHub : Hub {
        private ITestMethods methods;
        private TemporaryData temp;
        private List<string> concepts;
        private static Dictionary<string,List<TemporaryData>> data;
        public TestHub (ITestMethods _methods) {
            this.methods = _methods;
        }
        public async Task newMessage (string username, string value) {
            await Clients.All.SendAsync ("messageReceived", username, value);
        }
        // public async Task GetAllTechnoligies () {
        //     var tech = methods.GetAllTechnologies ();
        //     await Clients.Caller.SendAsync ("GotAllTechnoligies", tech);
        // }
        // public async Task GetAllQuestions (string technology, string concept, int blooms) {
        //     List<Question> questions = new List<Question>();
        //     if (concepts.Contains (concept)) {
        //         // questions = methods.GetAllQuestions (technology, (BloomTaxonomy) blooms);
        //     }
        //     await Clients.Caller.SendAsync ("GotAllQuestions", questions);
        // }
        // public async Task GetAllTopics (string tech) {
        //     var topics = methods.GetAllTopics (tech);
        //     await Clients.Caller.SendAsync ("GotAllTopics", topics);
        // }
        public async Task OnStart (string username, string tech) {
            temp = new TemporaryData (tech);
            methods.OnStart (temp, username, tech);
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
            temp.TempScore += methods.EvaluateAnswer (QuestionId, OptionId);
            await Clients.Caller.SendAsync ("Answer Evaluated");
        }

        public override async Task OnConnectedAsync () {

            await base.OnConnectedAsync ();
        }

        public override async Task OnDisconnectedAsync (Exception exception) {
            await base.OnDisconnectedAsync (exception);
        }
    }
}