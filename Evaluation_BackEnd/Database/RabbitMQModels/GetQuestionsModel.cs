using System.Collections.Generic;
using Evaluation_BackEnd.Models;

namespace Evaluation_BackEnd.RabbitMQModels
{
    public class GetQuestionsRequestModel
    {
        public string username{get;set;}
        public string tech{get;set;}
        public List<string> concepts;
        public GetQuestionsRequestModel(string _username, string _tech,List<string> _concepts)
        {
            username = _username;
            tech = _tech;
            concepts.Clear();
            concepts.AddRange(_concepts);
        }
    }
}