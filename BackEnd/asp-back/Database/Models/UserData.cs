using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learners.Models
{
    public class UserData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserName{get;set;}
        public List<QuizData> QuizDatas{get;set;}
    }
}