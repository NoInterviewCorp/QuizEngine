using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evaluation_BackEnd.Models;
using Evaluation_BackEnd.RabbitMQModels;
using Evaluation_BackEnd.StaticData;
using Learners.Services;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;

namespace Evaluation_BackEnd.Persistence
{
    public class LearnersMethods : ITestMethods
    {
        private static QueueHandler queuehandler;
        public LearnersMethods(QueueHandler _queuehandler)
        {
            // graphclient = _graphclient;
            queuehandler = _queuehandler;
        }

        public async Task EvaluateAnswer(string username, string QuestionId, int OptionId)
        {
            var question = TemporaryQuizData.TemporaryUserData[username].QuestionsAttempted.FirstOrDefault(v => v.QuestionId == QuestionId);
            if (question != null)
            {
                if (question.CorrectOptionId == OptionId)
                {
                    foreach (var concept in question.Concepts)
                    {
                        var checkIfConceptExistInUserData = TemporaryQuizData.TemporaryUserData[username].ConceptsAttempted.FirstOrDefault(c => c.ConceptName == concept.Name);
                        if (checkIfConceptExistInUserData != null)
                        {
                            TemporaryQuizData.TemporaryUserData[username].ConceptsAttempted
                                .FirstOrDefault(c => c.ConceptName == concept.Name)
                                .TotalQuestionAttempted++;
                            SendEvaluationToGraph(username, concept.Name, (int)question.BloomLevel);
                        }
                    }
                    Console.WriteLine("answer to the question ");
                    Console.WriteLine(question.ProblemStatement);
                    Console.WriteLine("is right");
                }
                else
                {
                    foreach (var concept in question.Concepts)
                    {
                        var checkIfConceptExistInUserData = TemporaryQuizData.TemporaryUserData[username].ConceptsAttempted.FirstOrDefault(c => c.ConceptName == concept.Name);
                        if (checkIfConceptExistInUserData != null)
                        {
                            TemporaryQuizData.TemporaryUserData[username].ConceptsAttempted.FirstOrDefault(c => c.ConceptName == concept.Name).TotalQuestionAttempted++;
                        }
                    }
                    Console.WriteLine("answer to the question ");
                    Console.WriteLine(question.ProblemStatement);
                    Console.WriteLine("is right");
                }
            }
            await queuehandler.hubContext.Clients.Client(ConnectionData.userconnectiondata[username]).SendAsync("GetQuestion");
        }
        public void SendEvaluationToGraph(string username, string concept, int bloom)
        {
            var requestdata = new ResultWrapper(username, concept, bloom);
            var serilaizeddata = requestdata.Serialize();
            queuehandler.Model.BasicPublish("KnowledgeGraphExchange", "Result.Update", null, serilaizeddata);
        }
        public async void OnFinish(Object Username)
        {
            var username = (string)Username;
            var tempdata = TemporaryQuizData.TemporaryUserData[username];
            QuizData quizdata = new QuizData(tempdata.TechName,tempdata.AttemptedOn,tempdata.ConceptsAttempted);
            UserData userdata = new UserData(username,quizdata);
            queuehandler.Model.BasicPublish(exchange:"KnowledgeGraphExchange",
                routingKey:"User.QuizData",
                basicProperties:null,
                body:userdata.Serialize());
            await queuehandler.hubContext.Clients.Client(ConnectionData.userconnectiondata[username]).SendAsync("Quiz Over",userdata);
        }

        public void OnStart(TemporaryData temp, string username)
        {
            TemporaryQuizData.TemporaryUserData[username] = temp;
        }

        public void GetQuestionsBatch(string username, string tech, List<string> concepts)
        {
            Console.WriteLine("---Interface method invoked---");
            try
            {
                var RequestData = new QuestionsBatchRequest(username, tech, concepts);
                var serializeddata = RequestData.Serialize();
                queuehandler.Model.BasicPublish(exchange: "KnowledgeGraphExchange",
                    routingKey: "Question.Batch",
                    basicProperties: null,
                    body: serializeddata);

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public void StartTimer(string Username)
        {
            Console.WriteLine("---Timer Started---");
            var timer = new System.Threading.Timer(OnFinish, Username, 300000, -1);
        }
    }
}