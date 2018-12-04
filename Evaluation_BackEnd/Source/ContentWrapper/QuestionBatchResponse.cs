using System.Collections.Generic;
using Evaluation_BackEnd.Models;

namespace Evaluation_BackEnd.RabbitMQModels {
    public class QuestionBatchResponse {
        public string username { get; set; }
        public Dictionary<string, List<Question>> questions;
        public QuestionBatchResponse (string _username) {
            username = _username;
            questions = new Dictionary<string, List<Question>> ();
        }
    }
}