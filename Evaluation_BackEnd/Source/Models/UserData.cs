using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluation_BackEnd.Models
{
    public class UserData
    {
        public string username { get; set; }
        public QuizData data;
        // public List<Question> questions;
        public UserData(QuizData _data)
        {
            data = _data;
        }
    }
}