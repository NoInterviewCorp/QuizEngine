using System;
using System.ComponentModel.DataAnnotations;

namespace Learners.Models
{
    public class QuizData
    {
        [Key]
        public string QuizId{get;set;}
        public string TechName{get;set;}
        public int TopicCompleted{get;set;}
        public BloomsLevel Blooms{get;set;}
        public string AttemptedOn{get;set;}
        public bool IsCompleted{get;set;}
        public string UserName{get;set;}
    }
}