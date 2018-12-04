using System;
using System.Collections.Generic;
using Evaluation_BackEnd.Models;
namespace Evaluation_BackEnd.Persistence {
    public interface ITestMethods

    {
        // List<Technology> GetAllTechnologies();
        // List<Topic> GetAllTopics(string technology);
        // List<Question> GetAllQuestions(string technology,string topic,BloomsLevel blooms);
        
        void OnStart (TemporaryData temp, string username);
        void OnFinish (UserData data);
        void GetQuestionsBatch (string username, string tech, List<string> concepts);
        void GetQuestions (String username, string tech, string concept);
        bool CountQuizAttempts (string tech, string username);
        void RequestConceptFromTechnology (string username, string tech);
        void EvaluateAnswer (string username, string QuestionId, string OptionId);
    }
}