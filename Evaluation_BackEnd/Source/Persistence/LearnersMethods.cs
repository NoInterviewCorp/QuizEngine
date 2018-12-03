using System;
using System.Collections.Generic;
using System.Linq;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.RabbitMQModels;
using Evaluation_BackEnd.StaticData;
using Learners.Services;
using Microsoft.EntityFrameworkCore;
using Neo4j.Driver.V1;
using RabbitMQ.Client;

namespace Evaluation_BackEnd.Persistence {
    public class LearnersMethods : ITestMethods {
        // public LearnersContext context;
        // private static GraphDbConnection graphclient;
        private static QueueHandler queuehandler;
        public LearnersMethods ( QueueHandler _queuehandler) {
            // graphclient = _graphclient;
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

        public void EvaluateAnswer (string username, string QuestionId, string OptionId) {
            var userdata = TemporaryQuizData.data[username];
            foreach (KeyValuePair<string, List<Question>> entry in userdata.QuestionsAttempted) {
                var question = entry.Value.FirstOrDefault (id => id.Id == QuestionId);
                if (question != null) {
                    if (question.CorrectOptionId == OptionId) {
                        TemporaryQuizData.data[username].ConceptsAttempted[entry.Key].QuestionAttemptedCorrect++;
                        TemporaryQuizData.data[username].ConceptsAttempted[entry.Key].TotalQuestionAttempted++;
                    } else {
                        TemporaryQuizData.data[username].ConceptsAttempted[entry.Key].TotalQuestionAttempted++;
                    }
                }
            }
        }

        public void OnFinish (UserData data) {
            throw new NotImplementedException ();
        }

        public void OnStart (TemporaryData temp, string username) {
            TemporaryQuizData.data[username] = temp;
        }

        public void GetQuestionsBatch (string username, string tech, List<string> concepts) {
            var RequestData = new QuestionsBatchRequest (username, tech, concepts);
            var serializeddata = RequestData.Serialize ();
            queuehandler.model.BasicPublish ("KnowledgeExchange", "Routing Key", null, serializeddata);
        }

        public void RequestConceptFromTechnology (string username, string tech) {
            var temp = new ConceptRequest (username, tech);
            var serializeddata = temp.Serialize ();
            queuehandler.model.BasicPublish ("KnowledgeExchange", "Routing key", null, serializeddata);
        }

        public void GetQuestions (string username, string tech, string concept) {
            var temporary = new QuestionsRequest (username, tech, concept);
            var serializeddata = temporary.Serialize ();
            queuehandler.model.BasicPublish ("KnowledgeExchange", "Routing key", null, serializeddata);
        }
    }
}