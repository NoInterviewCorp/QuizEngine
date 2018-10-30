using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learners.Models
{
    public class Option
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OptionId{get;set;}
        public string Content{get;set;}
        public bool IsCorrect{get;set;}
        public string QuestionId{get;set;}
    }
}