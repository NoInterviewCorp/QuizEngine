using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_back.hubs;
using Learners.Models;
using Learners.Persistence;
using Learners.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Neo4jClient;
using Newtonsoft.Json;
namespace asp_back.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        public ITestMethods methods;
        private GraphDbConnection graphclient;
        public ValuesController ( /* ILearnersMethods _method*/ GraphDbConnection _graphclient) {
            // this.methods = _method;
            graphclient = _graphclient;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get () {
            Console.WriteLine(graphclient.graph.IsConnected);
            if (graphclient.graph.IsConnected) {
                var result = await graphclient.graph.Cypher
                    .Merge ("(u:User{Id:124})")
                    .OnCreate()
                    .Set("u={user}")
                    .WithParams(new {
                        user = new User{
                            Id= 124,
                            Name = "rohit"
                        }
                    })
                    .Return (u => u.As<User> ())
                    .ResultsAsync;
                return Ok (result.Single());
            } else {
                return NotFound ("not connected to the database");
            }
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}