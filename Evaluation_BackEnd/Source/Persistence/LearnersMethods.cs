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
            Console.WriteLine("Evaluate function called");
            Console.WriteLine(username +"   "+QuestionId+"   "+OptionId);
            var question = TemporaryQuizData.TemporaryUserData[username].QuestionsAttempted.FirstOrDefault(v => v.QuestionId == QuestionId);
            Console.WriteLine(question.QuestionId);
            if (question != null)
            {
                Console.WriteLine(question.CorrectOptionId);
                Console.WriteLine(OptionId);
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
                            Console.WriteLine("debug log "+TemporaryQuizData.TemporaryUserData[username].ConceptsAttempted
                                .FirstOrDefault(c => c.ConceptName == concept.Name)
                                .TotalQuestionAttempted);
                            SendEvaluationToGraph(username, concept.Name, (int)question.BloomLevel);
                        }
                    }
                    Console.WriteLine("answer to the question \"{0}\" is right",question.ProblemStatement);
                    Console.WriteLine("Sending data to queue");
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
                    Console.WriteLine("answer to the question \"{0}\" is wrong",question.ProblemStatement);
                }
            }
            await queuehandler.hubContext.Clients.Client(ConnectionData.userconnectiondata[username]).SendAsync("Answer Evaluated");
        }
        public void SendEvaluationToGraph(string username, string concept, int bloom)
        {
            var requestdata = new ResultWrapper(username, concept, bloom);
            var serilaizeddata = requestdata.Serialize();
            queuehandler.Model.BasicPublish("KnowledgeGraphExchange", "Result.Update", null, serilaizeddata);
        }

        public void OnStart(TemporaryData temp, string username)
        {
            if (!(TemporaryQuizData.TemporaryUserData.TryAdd(username,temp)))
            {
                TemporaryQuizData.TemporaryUserData.Remove(username);
                TemporaryQuizData.TemporaryUserData.Add(username,temp);
            }
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
    }
}