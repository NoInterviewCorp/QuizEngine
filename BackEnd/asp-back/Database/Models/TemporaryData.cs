using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learners.Models
{
    public class TemporaryData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserName { get; set; }
        public string QuizId { get; set; }
        public string TechName { get; set; }
        public int TopicCompleted { get; set; }
        public BloomsLevel Blooms { get; set; }
        public DateTime AttemptedOn { get; set; }
        public bool IsCompleted { get; set; }
    }
}