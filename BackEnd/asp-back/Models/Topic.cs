using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace EFCoreDatabase
{
    public class Topic
    {
        [Key ,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TopicId{get;set;}
        [Required,MaxLength(50),MinLength(3)]
        public int TechnologyId {get;set;}
        
    }
}