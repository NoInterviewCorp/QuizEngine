using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learners.Models
{
    public  class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string QuestionId{get;set;}
        [Required]
        public string ProblemStatement{get;set;}
        public string ResourceLink{get;set;}
        public List<Option> Options { get; set; }
        public BloomsLevel BloomLevel{get;set;}
        public bool HasPublished { get; set; }

        public string TopicId{get;set;}
    }
}