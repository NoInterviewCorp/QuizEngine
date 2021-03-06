using System;
using System.Collections.Generic;
using Evaluation_BackEnd.Models;

namespace Evaluation_BackEnd.RabbitMQModels {
    public class QuestionsBatchRequest {
        public string username { get; set; }
        public string tech { get; set; }
        public List<string> concepts;
        public QuestionsBatchRequest (string _username, string _tech, List<string> _concepts) {
            username = _username;
            tech = _tech;
            concepts.Clear ();
            concepts.AddRange (_concepts);
        }
    }
}