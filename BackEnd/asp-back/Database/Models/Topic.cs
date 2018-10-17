using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace Learners.Models
{
    public class Topic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TopicId { get; set; }
        public string TopicName{get;set;}
        public List<Question> Questions { get; set; }
        public int TechnologyId { get; set; }

    }
}