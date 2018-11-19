using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace Learners.Models {
    public class User {

        [Key, DatabaseGenerated (DatabaseGeneratedOption.None)]
        public string Name { get; set; }
        public int Id {get;set;}
    }
}