using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluation_BackEnd.Models {
    public class QuizData {
        [Key, DatabaseGenerated (DatabaseGeneratedOption.None)]
        public string QuizId { get; set; }
        public string TechName { get; set; }
        public int TopicCompleted { get; set; }
        public BloomTaxonomy Blooms { get; set; }
        public string AttemptedOn { get; set; }
        public bool IsCompleted { get; set; }
    }
}