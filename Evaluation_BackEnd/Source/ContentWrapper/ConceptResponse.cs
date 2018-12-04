using System.Collections.Generic;

namespace Evaluation_BackEnd.RabbitMQModels {
    public class ConceptResponse {
        public string username { get; set; }
        public Dictionary<string, List<string>> concepts;
    }
}