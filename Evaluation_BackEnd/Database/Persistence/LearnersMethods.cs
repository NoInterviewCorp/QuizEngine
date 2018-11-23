using System;
using System.Collections.Generic;
using System.Linq;
using Evaluation_BackEnd.Models;
using Learners.Services;
using Microsoft.EntityFrameworkCore;
using Neo4j.Driver.V1;
namespace Evaluation_BackEnd.Persistence {
    public class LearnersMethods : ITestMethods {
        // public LearnersContext context;
        private static GraphDbConnection graphclient;
        private static QueueHandler queuehandler;
        public LearnersMethods (GraphDbConnection _graphclient, QueueHandler _queuehandler) {
            graphclient = _graphclient;
            queuehandler = _queuehandler;
        }

        public void AddResult (TemporaryData temporary) {
            throw new NotImplementedException ();
        }

        public int BloomLevel (string QuestionId) {
            throw new NotImplementedException ();
        }

        public int CheckBloomLevelOfTopic (int score) {
            throw new NotImplementedException ();
        }

        public bool CheckOption (string optionId) {
            throw new NotImplementedException ();
        }

        public bool CheckQuiz (string tech, string username) {
            throw new NotImplementedException ();
        }

        public int EvaluateAnswer (string QuestionId, string OptionId) {
            throw new NotImplementedException ();
        }

        public void OnFinish(User data)
        {
            throw new NotImplementedException();
        }

        public void OnStart(TemporaryData temp, string username, string tech)
        {
            throw new NotImplementedException();
        }
    }
}