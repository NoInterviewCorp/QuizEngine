using System.Collections.Generic;
using System.Linq;
using Learners.Models;
using Microsoft.EntityFrameworkCore;

namespace Learners.Persistence
{
    public class LearnersMethod : ILearnersMethods
    {
        private LearnersContext context;
        LearnersMethod(LearnersContext _context)
        {
            this.context = _context;
        }
        /// <summary>
        /// To get all Questions from the perticular topic according to bloom level
        /// </summary>
        /// <param name="technology">Technology in which the user is giving test</param>
        /// <param name="topic">Topic in the stated topic</param>
        /// <param name="blooms">Bloom level</param>
        /// <returns>List of question from the topic of asked technology and blooms level</returns>
        public List<Question> GetAllQuestions(string technology, string topic,BloomsLevel BloomLevel)
        {
            //var obj=Guid.NewGuid().ToString();
            var topics = GetAllTopics(technology);
            if (topics == null)
            {
                return null;
            }
            var topicObj = topics.FirstOrDefault(t => t.TopicName == topic);
            if (topicObj == null)
            {
                return null;
            }
            string topicId = topicObj.TopicId;
            List<Question> questions = context.Questions
                                        .Include(q => q.Options)
                                        .Where(q => q.HasPublished && q.TopicId == topicId && q.BloomLevel==BloomLevel)
                                        .ToList();
            return questions;
        }
        /// <summary>
        /// To get all Technology in the database
        /// </summary>
        /// <returns>The list of Technology present in the database </returns>

        public List<Technology> GetAllTechnologies()
        {
            return context.Technologies.Include(t => t.Topics).ToList();
        }
        /// <summary>
        /// Retrieve the Topics present in the perticular technology
        /// </summary>
        /// <param name="technology">Technology you want to get all the topics of</param>
        /// <returns>List of Topic resent in specified technology</returns>

        public List<Topic> GetAllTopics(string technology)
        {
            var technologies = GetAllTechnologies();
            if (technologies == null)
            {
                return null;
            }
            var tech = technologies.FirstOrDefault(t => t.Technologyname == technology);
            if (tech == null)
            {
                return null;
            }
            List<Topic> topics = tech.Topics;
            return topics;
        }
        public bool CheckOption(string OptionId)
        {
            var ans =context.Options.FirstOrDefault(t=>t.OptionId==OptionId);
            if(ans.IsCorrect==true)
            {
                return true;
            }
            return false;
        }
        public int BloomLevel(string QuestionId)
        {
            var level = context.Questions.FirstOrDefault(t=>t.QuestionId==QuestionId);
            return (int)level.BloomLevel;
        }
        public int Evaluate(string QuestionId,string OptionId)
        {
            if(CheckOption(OptionId))
            {
                return BloomLevel(QuestionId);
            }
            else
                return 0;
        }
        public int CheckBloomLevelOfTopic(int score)
        {
            var values = context.Thresholds;
            foreach (var val in values)
            {
               if(Enumerable.Range(val.MinThreshold,val.MaxThreshold).Contains(score))
               {
                   return val.BloomLevel;
               }
            }
            return 1;
        }
    }
}