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
            await Clients.Caller.SendAsync("GotAllQuestions",topics);
        }
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}