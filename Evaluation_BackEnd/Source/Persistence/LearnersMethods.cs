using System;
using System.Collections.Generic;
using System.Linq;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.RabbitMQModels;
using Learners.Services;
using Microsoft.EntityFrameworkCore;
using Neo4j.Driver.V1;
using RabbitMQ.Client;

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

        public bool CountQuizAttempts (string tech, string username) {
            throw new NotImplementedException ();
        }

        public int EvaluateAnswer (string QuestionId, string OptionId) {
            throw new NotImplementedException ();
        }

        public void OnFinish (UserData data) {
            throw new NotImplementedException ();
        }

        public void OnStart (TemporaryData temp, string username, string tech) {
            throw new NotImplementedException ();
        }

        public void GetQuestionsBatch (string username, string tech, List<string> concepts) {
            var RequestData = new QuestionsBatchRequestModel (username, tech, concepts);
            var serializeddata = RequestData.Serialize ();
            queuehandler.model.BasicPublish ("KnowledgeExchange", "Routing Key", null, serializeddata);
        }

        public void RequestConceptFromTechnology (string username, string tech) {
            var temp = new ConceptRequestModel (username, tech);
            var serializeddata = temp.Serialize ();
            queuehandler.model.BasicPublish ("KnowledgeExchange", "Routing key", null, serializeddata);
        }

        public void GetQuestions (string username, string tech, string concept) {
            var temporary = new QuestionsRequestModel (username, tech, concept);
            var serializeddata = temporary.Serialize ();
            queuehandler.model.BasicPublish ("KnowledgeExchange", "Routing key", null, serializeddata);
        }
    }
}