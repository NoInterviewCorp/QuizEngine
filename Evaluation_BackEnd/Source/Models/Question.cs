using System.Collections.Generic;
using Newtonsoft.Json;

namespace Evaluation_BackEnd.Models {
    public class Question {
        public string Id { get; set; }
        [JsonIgnore]
        public BloomTaxonomy Bloomlevel { get; set; }
        [JsonIgnore]
        public string CorrectOptionId { get; set; }
        public string ProblemStatement { get; set; }
        public List<Option> Options;
    }
}