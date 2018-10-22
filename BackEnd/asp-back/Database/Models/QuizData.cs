using System;

namespace Learners.Models
{
    public class QuizData
    {
        public string QuizId{get;set;}
        public string TechName{get;set;}
        public int TopicCompleted{get;set;}
        public BloomsLevel Blooms{get;set;}
        public DateTime AttemptedOn{get;set;}
        public bool IsCompleted{get;set;}
        public string UserName{get;set;}
    }
}