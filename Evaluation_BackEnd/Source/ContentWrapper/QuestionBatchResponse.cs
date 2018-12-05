using System.Collections.Generic;
using Evaluation_BackEnd.Models;

namespace Evaluation_BackEnd.RabbitMQModels {
    public class QuestionBatchResponse {
        public string Username { get; set; }
        public Dictionary<string, List<Question>> questions = new Dictionary<string, List<Question>>();
        public QuestionBatchResponse()
        {
            
        }
        public QuestionBatchResponse (string _username) {
            Username = _username;
        }
    }
}