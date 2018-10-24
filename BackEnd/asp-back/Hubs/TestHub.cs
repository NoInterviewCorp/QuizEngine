using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Learners.Persistence;
using Learners.Models;

namespace asp_back.hubs
{
    public class TestHub : Hub
    {
        private ILearnersMethods methods;
        private TemporaryData temp = new TemporaryData();
        TestHub(ILearnersMethods _methods)
        {
            this.methods = _methods;
        }
        public async Task GetAllTechnoligies()
        {
            var tech = methods.GetAllTechnologies();
            await Clients.Caller.SendAsync("GotAllTechnoligies", tech);
        }
        public async Task GetAllQuestions(string technology, string topic,int blooms)
        {
            var questions = methods.GetAllQuestions(technology, topic,(BloomsLevel)blooms);
            await Clients.Caller.SendAsync("GotAllQuestions", questions);
        }
        public async Task GetAllTopics(string tech)
        {
            var topics = methods.GetAllTopics(tech);
            await Clients.Caller.SendAsync("GotAllTopics",topics);
        }
        public async Task OnStart(string username,string tech)
        {
            string id = new Guid().ToString();
            temp.UserName=username;
            temp.TechName=tech;
            temp.QuizId = id;
            temp.IsCompleted = false;
            temp.AttemptedOn = DateTime.Today.ToString("dd/MM/yyyy");
            temp.AttemptedOn += " "+DateTime.Now.ToString("HH:mm:ss");
            temp.TempScore=0;
            temp.Blooms=0;
            methods.OnStart(temp);
            await Clients.Caller.SendAsync("Temporary Object Created");
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}