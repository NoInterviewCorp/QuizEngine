using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Learners.Models
{
    public class Technology
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TechnologyId{get;set;}
        [Required]
        public string Technologyname{get;set;}
        [Required]
        public List<Topic> Topics{get;set;}       
    }
}