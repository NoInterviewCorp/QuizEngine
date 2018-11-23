using System.Collections.Generic;
using Evaluation_BackEnd.Models;
namespace Evaluation_BackEnd.Persistence {
    public interface ITestMethods

    {
        // List<Technology> GetAllTechnologies();
        // List<Topic> GetAllTopics(string technology);
        // List<Question> GetAllQuestions(string technology,string topic,BloomsLevel blooms);
        bool CheckOption (string optionId);
        void OnStart (TemporaryData temp, string username, string tech);
        void OnFinish (User data);
        bool CheckQuiz (string tech, string username);
        void AddResult (TemporaryData temporary);
        int CheckBloomLevelOfTopic (int score);
        int EvaluateAnswer (string QuestionId, string OptionId);
        int BloomLevel (string QuestionId);
    }
}