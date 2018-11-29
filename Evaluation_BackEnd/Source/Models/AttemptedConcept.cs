using System.Collections.Generic;

namespace Evaluation_BackEnd.Models {
    public class AttemptedConcept {
        public int QuestionAttemptedCorrect { get; set; }
        public int QuestionAttemptedWrong { get; set; }
        public BloomTaxonomy bloomlevel { get; set; }
        public AttemptedConcept (string concept) {
            // this.concept = concept;
            QuestionAttemptedCorrect = 0;
            QuestionAttemptedWrong = 0;
            bloomlevel = (BloomTaxonomy) 1;
        }
    }
}