using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Evaluation_BackEnd.Models {
    public class TemporaryData {
        public string TechName { get; set; }
        // public BloomTaxonomy Blooms { get; set; }
        public string AttemptedOn { get; set; }
        public bool IsCompleted { get; set; }
        public Dictionary<string, AttemptedConcept> ConceptsAttempted { get; set; }

        [BsonIgnore]
        public Dictionary<string, List<Question>> QuestionsAttempted;
        public TemporaryData (string tech, List<string> concepts) {
            TechName = tech;
            foreach (var concept in concepts) {
                ConceptsAttempted[concept] = (new AttemptedConcept (concept));
            }
            IsCompleted = false;
            AttemptedOn = DateTime.Today.ToString ("dd/MM/yyyy") + " " + DateTime.Now.ToString ("HH:mm:ss");
            // Blooms = (BloomTaxonomy) (1);
        }
    }
}