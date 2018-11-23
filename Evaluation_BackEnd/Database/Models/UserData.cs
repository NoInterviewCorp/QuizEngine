using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluation_BackEnd.Models {
    public class UserData {
        [Key, DatabaseGenerated (DatabaseGeneratedOption.None)]
        public string UserName { get; set; }
    }
}