using System;
using System.Collections.Generic;
using System.Linq;
using Learners.Models;
using Learners.Services;
using Microsoft.EntityFrameworkCore;
using Neo4j.Driver.V1;
namespace Learners.Persistence {
    public class LearnersMethod
    {
        // public LearnersContext context;
        private static GraphDbConnection graphclient;
        public LearnersMethod (GraphDbConnection _graphclient) {
            graphclient = _graphclient;
        }
        // public bool CheckOption (string OptionId) {
        //     var ans = context.Options.FirstOrDefault (t => t.OptionId == OptionId);
        //     if (ans.IsCorrect == true) {
        //         return true;
        //     }
        //     return false;
        // }
        // public int BloomLevel (string QuestionId) {
        //     var level = context.Questions.FirstOrDefault (t => t.QuestionId == QuestionId);
        //     return (int) level.BloomLevel;
        // }
        // public int EvaluateAnswer (string QuestionId, string OptionId) {
        //     if (CheckOption (OptionId)) {
        //         return BloomLevel (QuestionId);
        //     } else
        //         return 0;
        // }
        // public int CheckBloomLevelOfTopic(int score)
        // {
        //     var values = context.Thresholds;
        //     foreach (var val in values)
        //     {
        //        if(Enumerable.Range(val.MinThreshold,val.MaxThreshold).Contains(score))
        //        {z
        //            return val.BloomLevel;
        //        }
        //     }
        //     return 1;
        // }
        // public void AddResult (TemporaryData temporary) {
        //     context.Temporaries.Add (temporary);
        //     context.SaveChanges ();
        // }
        // public void CalculateResult()
        // {
        // }
        public void OnStart (TemporaryData temp,string username) {
            if(graphclient.graph.IsConnected)
            {
                graphclient.graph.Cypher
                    .Match("(u:User{UserName})")
                    .WithParam("UserName",username)
                    .Create("(t:TemporaryData{temp})")
                    .WithParam("temp",temp)
                    .Create("(u)-[HAS_TEMPORARY_DATA]->(t)")
                    .ExecuteWithoutResults();  
            }
        }

        // public void OnFinish (UserData data) {
        //     context.UserDatas.Add (data);
        //     context.SaveChanges ();
        // }

        // public bool CheckQuiz (string tech, string username) {
        //     var check = context.QuizDatas.FirstOrDefault (t => t.UserName == username && t.TechName == tech);
        //     if (check != null) {
        //         return true;
        //     } else {
        //         return false;
        //     }
        // }
        // public List<Concept> GetConcepts () {
        //     return context.Concepts.ToList ();
        // }

        // public Concept GetConceptByName (string name) {
        //     return context.Concepts.FirstOrDefault (c => c.Name == name);
        // }

        // public List<Resource> GetResources () {
        //     return context.Resources.Include (r => r.ResourceConcepts).ToList ();
        // }

        // public Resource GetResourceByLink (string link) {
        //     return context.Resources.FirstOrDefault (r => r.ResourceLink == link);
        // }

        // public List<Resource> GetResourceByTechnology (string technology) {
        //     var techObj = context.Technologies.FirstOrDefault (t => t.Name == technology);
        //     if (techObj != null) {
        //         List<Resource> resources = new List<Resource> ();
        //         var listRT = context.ResourceTechnologies.Include (rt => rt.Resource).Where (rt => rt.TechnologyId == techObj.TechnologyId).ToList ();
        //         foreach (ResourceTechnology rt in listRT) {
        //             resources.Add (rt.Resource);
        //         }
        //         return resources;
        //     }
        //     return null;
        // }

        // public IQueryable<LearningPlan> GetLearningPlans () {
        //     return context.LearningPlan.Include (lp => lp.Topics);
        // }

        // public IQueryable<LearningPlan> GetLearningPlansByUserName (string userName) {
        //     return context.LearningPlan.Where (lp => lp.UserName == userName);
        // }

        // public LearningPlan GetLearningPlanById (string learningPlanId) {
        //     return context.LearningPlan.FirstOrDefault (lp => lp.LearningPlanId == learningPlanId);
        // }

        // public List<LearningPlan> GetLearningPlansByTechnology (string technology) {
        //     return context.LearningPlan.Where (lp => lp.Technology.Name == technology).ToList ();
        // }

        // Technology Controller Function

        // public List<Technology> GetAllTechnologies () {
        //     return context.Technologies.ToList ();
        // }

        // public Technology GetTechnologyByName (string name) {
        //     return context.Technologies.FirstOrDefault (t => t.Name == name);
        // }
        // public List<Question> GetQuestions () {
        //     return context.Questions.ToList ();
        // }
        // public List<Question> GetQuestionsByTechnology (Technology tech) {
        //     return context.Questions.Where (t => t.Technology == tech).ToList ();
        // }
        // public List<Question> GetQuestionsByBloomLevel (int bloom) {
        //     int count = 10;
        //     int counter = 1;
        //     List<Question> questions = new List<Question> ();
        //     if (bloom < 3) {
        //         while (count != 1) {
        //             var temp = context.Questions.Where (q => (int) q.BloomLevel == counter).ToList ();
        //             if (count % 2 == 0) {
        //                 var question = temp.OrderBy (r => Guid.NewGuid ()).Take (count / 2).ToList ();
        //                 questions.AddRange (question);
        //             } else {
        //                 var question = temp.OrderBy (r => Guid.NewGuid ()).Take ((count / 2) + 1).ToList ();
        //                 questions.AddRange (question);
        //             }
        //             counter++;
        //             count = count / 2;
        //         }
        //         return questions.ToList ();
        //     } else {
        //         var temp = context.Questions.Where (q => (int) q.BloomLevel == bloom).ToList ();
        //         var question = temp.OrderBy (r => Guid.NewGuid ()).Take (3).ToList ();
        //         questions.AddRange (question);
        //         temp = context.Questions.Where (q => (int) q.BloomLevel == (bloom - 1)).ToList ();
        //         question = temp.OrderBy (r => Guid.NewGuid ()).Take (7).ToList ();
        //         questions.AddRange (question);
        //         return questions.ToList ();
        //     }
        // }
        // public List<Question> GetQuestionsByConceptOfATech (string technology, string concept, int bloom=3) {
        //     int count = 10;
        //     int counter = 1;
        //     List<Question> questions = new List<Question> ();
        //     string technologyId = context.Technologies.FirstOrDefault (t => t.Name.ToLower () == technology.ToLower ()).TechnologyId;
        //     string conceptId = context.Concepts.FirstOrDefault (c => c.Name.ToLower () == concept.ToLower ()).ConceptId;
        //     if (bloom < 3) {
        //         while (count != 1) {
        //             var temp = context.Questions.Include (q => q.ConceptQuestions)
        //                 .Where (q =>
        //                     (q.TechnologyId == technologyId) &&
        //                     (q.ConceptQuestions.Where (cq => cq.ConceptId == conceptId) != null)
        //                 ).Where (q => (int) q.BloomLevel == bloom).ToList ();
        //             if (count % 2 == 0) {
        //                 var question = temp.OrderBy (r => Guid.NewGuid ()).Take (count / 2).ToList ();
        //                 questions.AddRange (question);
        //             } else {
        //                 var question = temp.OrderBy (r => Guid.NewGuid ()).Take ((count / 2) + 1).ToList ();
        //                 questions.AddRange (question);
        //             }
        //             counter++;
        //             count = count / 2;
        //         }
        //         return questions.ToList ();
        //     } else {
        //         var temp = context.Questions.Include (q => q.ConceptQuestions)
        //             .Where (q =>
        //                 (q.TechnologyId == technologyId) &&
        //                 (q.ConceptQuestions.Where (cq => cq.ConceptId == conceptId) != null)
        //             ).Where (q => (int) q.BloomLevel == bloom).ToList ();
        //         var question = temp.OrderBy (r => Guid.NewGuid ()).Take (3).ToList ();
        //         questions.AddRange (question);
        //         temp = context.Questions.Include (q => q.ConceptQuestions)
        //             .Where (q =>
        //                 (q.TechnologyId == technologyId) &&
        //                 (q.ConceptQuestions.Where (cq => cq.ConceptId == conceptId) != null)
        //             ).Where (q => (int) q.BloomLevel == bloom).ToList ();
        //         question = temp.OrderBy (r => Guid.NewGuid ()).Take (7).ToList ();
        //         questions.AddRange (question);
        //         return questions;
        //     }

        // }
        // public List<Question> GetQuestionsByConcept(string conceptId , int blooms)
    }
}