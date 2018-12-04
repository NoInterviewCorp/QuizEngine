using System.Threading.Tasks;
using Learners.Services;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace Evaluation_BackEnd.Controllers {
    public class Data {
        public string username;
        public string tech;
    }

    [Route ("[controller]")]
    [ApiController]
    public class ForbiddenController : ControllerBase {
        private IModel _queue;
        public ForbiddenController (QueueHandler handler) {
            _queue = handler.model;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get () {
            return Forbid ();
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public IActionResult Get (int id) {
            return Forbid ();
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync ([FromBody] Data data) {
            var serialized = data.Serialize ();
            _queue.BasicPublish (exchange: "KnowledgeExchange",routingKey:null,basicProperties:null,body:serialized);
            await Task.Yield ();
            return Forbid ();
        }

        // PUT api/values/5
        [HttpPut ()]
        public async Task<IActionResult> Put () {
            await Task.Yield ();
            return Forbid ();
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}