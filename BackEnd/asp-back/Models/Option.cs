using System.Collections.Generic;

namespace EFCoreDatabase
{
    public class Option
    {
        public int OptionId{get;set;}
        public string Content{get;set;}
        public bool IsCorrect{get;set;}
        public int QuestionId{get;set;}
    }
}