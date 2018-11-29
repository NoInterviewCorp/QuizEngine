using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace Evaluation_BackEnd.Models {
    public class Concept {
        public string Name { get; set; }
        public BloomTaxonomy bloomtaxonomy;
    }
}