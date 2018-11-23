using System.Collections.Generic;

namespace Evaluation_BackEnd.Models {
    public class Question {
        public int Id { get; set; }
        public string ProblemStatement { get; set; }
        public List<Option> Options;
    }
}