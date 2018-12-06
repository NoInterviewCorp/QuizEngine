using System.Collections.Generic;
using Newtonsoft.Json;

namespace Evaluation_BackEnd.Models
{
    public class Question
    {
        public string QuestionId { get; set; }
        [JsonIgnore]
        public BloomTaxonomy Bloomlevel { get; set; }
        [JsonIgnore]
        public Option CorrectOption { get; set; }
        public string ProblemStatement { get; set; }
        public List<Option> Options = new List<Option>();
    }
}