using System.Collections.Generic;
using Learners.Models;
namespace Learners.Persistence 
{
    public interface ILearnersMethond 
    {
        List<Technology> GetAllTechnologies();
        List<Topic> GetAllTopics(string technology);
        List<Question> GetAllQuestions(string technology,string topic);
        bool CheckOption(int optionId); 
    }
}