using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evaluation_BackEnd.Models
{
    public class UserData
    {
        public string Username { get; set; }
        public QuizData Data;
        public UserData(string username,QuizData data)
        {
            Username = username;
            Data = data;
        }
    }
}