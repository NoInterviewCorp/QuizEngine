using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluation_BackEnd.Models
{
    public class QuizData
    {
        public string TechName { get; set; }
        public string AttemptedOn { get; set; }
        // public bool IsCompleted { get; set; }
        public List<AttemptedConcept> ConceptsAttempted { get; set; }
    }
}