using System.Collections.Generic;
using Evaluation_BackEnd.Models;

namespace Evaluation_BackEnd.RabbitMQModels
{
    public class ResultWrapper
    {
        public string Username;
        public string Concept;
        public int Bloom;

        public ResultWrapper(string username, string concept, int bloom)
        {
            Username = username;
            Concept = concept;
            Bloom = bloom;
        }
    }
}