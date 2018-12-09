using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluation_BackEnd.Models;
namespace Evaluation_BackEnd.Persistence
{
    public interface ITestMethods

    {
        // List<Technology> GetAllTechnologies();
        // List<Topic> GetAllTopics(string technology);
        // List<Question> GetAllQuestions(string technology,string topic,BloomsLevel blooms);

        void OnStart(TemporaryData temp, string username);
        void EndQuiz(string username);
        void GetQuestionsBatch(string username, string tech, List<string> concepts);
        Task EvaluateAnswer(string username, string QuestionId, int OptionId);
        void RecommendResource(string username);
    }
}