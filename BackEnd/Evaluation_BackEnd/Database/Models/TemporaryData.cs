using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learners.Models {
    public class TemporaryData {
        [Key, DatabaseGenerated (DatabaseGeneratedOption.None)]
        public string TechName { get; set; }
        public BloomTaxonomy Blooms { get; set; }
        public string AttemptedOn { get; set; }
        public int TempScore { get; set; }
        public bool IsCompleted { get; set; }
        public TemporaryData (string tech) {
            TechName = tech;
            IsCompleted = false;
            AttemptedOn = DateTime.Today.ToString ("dd/MM/yyyy") + " " + DateTime.Now.ToString ("HH:mm:ss");
            TempScore = 0;
            Blooms = (BloomTaxonomy) (1);
        }
    }
}