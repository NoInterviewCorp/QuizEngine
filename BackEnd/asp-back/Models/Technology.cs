using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EFCoreDatabase
{
    public class Technology
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TechnologyId{get;set;}
        public string Technologyname{get;set;}
        public List<Topic> Topics{get;set;}       
    }
}