using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace Learners.Models
{
    public class Threshold
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ThresholdId{get;set;}
        public int BloomLevel{get;set;}
        public int MinThreshold{get;set;}
        public int MaxThreshold{get;set;}
    }
}