using System.Collections.Generic;
using Learners.Models;
namespace Learners.Persistence 
{
    public interface ILearnersMethods
    
    {
        List<Technology> GetAllTechnologies();
        List<Topic> GetAllTopics(string technology);
        List<Question> GetAllQuestions(string technology,string topic,BloomsLevel blooms);
        bool CheckOption(string optionId);
        void OnStart(TemporaryData temp);
        void OnFinish(UserData data);
        bool CheckQuiz(string tech,string username);
    }
}