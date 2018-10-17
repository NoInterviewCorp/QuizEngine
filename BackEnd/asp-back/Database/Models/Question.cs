using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Learners.Models
{
    public  class Question
    {
        [Required]
        public int? QuestionId{get;set;}
        [Required]
        public string ProblemStatement{get;set;}
        public string ResourceLink{get;set;}
        public List<Option> Options { get; set; }
        public BloomsLevel BloomLevel{get;set;}
        public bool HasPublished { get; set; }

        public int TopicId{get;set;}
    }
}