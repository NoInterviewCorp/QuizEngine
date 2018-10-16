using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace EFCoreDatabase
{
    public class Note
    {
        [Key ,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NoteId{get;set;}
        [Required,MaxLength(50),MinLength(3)]
        public string title{get;set;}
        [MaxLength(2000)]
        public string text{get;set;}
        [DefaultValue(false)]
        public bool pinned{get;set;}
        public IEnumerable<CheckList> checkList{ get; set; }
        public IEnumerable<Label> label{get;set;}
    }
}