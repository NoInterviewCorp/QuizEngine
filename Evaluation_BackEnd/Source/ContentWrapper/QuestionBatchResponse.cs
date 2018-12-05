using System.Collections.Generic;
using Evaluation_BackEnd.Models;

namespace Evaluation_BackEnd.RabbitMQModels {
    public class QuestionBatchResponse {
        public string Username { get; set; }
        public List<Question> ResponseList = new List<Question>();
        public QuestionBatchResponse()
        {
            
        }
        public QuestionBatchResponse (string _username) {
            Username = _username;
        }
    }
}