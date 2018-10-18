using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Learners.Persistence;
using Learners.Models;

namespace asp_back.hubs {
    public class TestHub : Hub {
        private ILearnersMethods methods;
        TestHub(ILearnersMethods _methods)
        {
            this.methods=_methods;
        }
        public async Task NewMessage(string username, string message)
        {
            await Clients.All.SendAsync("messageReceived", username, message);
        }
        public async Task SendMessage (string user, string message) {
            await Clients.All.SendAsync ("ReceiveMessage", user, message);
        }

        public Task SendMessageToCaller (string message) {
            return Clients.Caller.SendAsync ("ReceiveMessage", message);
        }
        public async Task GetAllTechnoligies ()
        {
            var tech = methods.GetAllTechnologies();
            await Clients.Caller.SendAsync("GetAllTechnoligies",tech);
        }
        public override async Task OnConnectedAsync () {
            await Groups.AddToGroupAsync (Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync ();
        }

        public override async Task OnDisconnectedAsync (Exception exception) {
            await Groups.RemoveFromGroupAsync (Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync (exception);
        }
    }
}