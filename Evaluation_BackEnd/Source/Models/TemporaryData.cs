using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Evaluation_BackEnd.Models
{
    public class TemporaryData
    {
        public string TechName { get; set; }
        // public BloomTaxonomy Blooms { get; set; }
        public string AttemptedOn { get; set; }
        public List<AttemptedConcept> ConceptsAttempted { get; set; }
        [JsonIgnore]
        public List<Question> QuestionsAttempted;
        public TemporaryData()
        {

        }
        public TemporaryData(string tech, List<string> concepts)
        {
            TechName = tech;
            ConceptsAttempted = new List<AttemptedConcept>();
            QuestionsAttempted = new List<Question>();
            foreach (var concept in concepts)
            {
                ConceptsAttempted.Add(new AttemptedConcept(concept));
            }
            AttemptedOn = DateTime.Today.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss");
            // Blooms = (BloomTaxonomy) (1);
        }
    }
}