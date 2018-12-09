using System.Collections.Generic;
using Evaluation_BackEnd.Models;

namespace Evaluation_BackEnd.RabbitMQModels
{
    public class ResourceResponse
    {
        public string Username { get; set; }
        public List<Resource> Resources;
        public ResourceResponse()
        {
            
        }
    }
}