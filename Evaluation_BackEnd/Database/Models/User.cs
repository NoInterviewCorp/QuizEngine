using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace Evaluation_BackEnd.Models {
    public class User {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}