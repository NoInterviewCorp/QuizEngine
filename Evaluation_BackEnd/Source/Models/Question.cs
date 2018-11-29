using System.Collections.Generic;

namespace Evaluation_BackEnd.Models {
    public class Question {
        public int Id { get; set; }
        public BloomTaxonomy Bloomlevel { get; set; }
        public string CorrectOptionId { get; set; }
        public string ProblemStatement { get; set; }
        public List<Option> Options;
    }
}