using System;
using System.Collections.Generic;
using Evaluation_BackEnd.Models;

namespace Evaluation_BackEnd.RabbitMQModels {
    public class QuestionsBatchRequest {
        public string Username { get; set; }
        public string Tech { get; set; }
        public List<string> Concepts;
        public QuestionsBatchRequest (string _username, string _tech, List<string> _concepts) {
            Username = _username;
            Tech = _tech;
            Concepts = new List<string>();
            Concepts.AddRange (_concepts);
        }
    }
}