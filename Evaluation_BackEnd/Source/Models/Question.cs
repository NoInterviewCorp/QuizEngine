using System.Collections.Generic;
using Newtonsoft.Json;

namespace Evaluation_BackEnd.Models
{
    public class Question
    {
        public string QuestionId { get; set; }
        public List<Concept> Concepts = new List<Concept>();
        public string ResourceId { get; set; }
        public BloomTaxonomy BloomLevel { get; set; }
        public string ProblemStatement { get; set; }
        public Option CorrectOption { get; set; }
        public List<Option> Options = new List<Option>();
    }
}