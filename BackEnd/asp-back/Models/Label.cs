using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EFCoreDatabase
{
    public class Label
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string LabelId{get;set;}
        public string labelname{get;set;}
        public int NoteId{get;set;}
        
    }
}