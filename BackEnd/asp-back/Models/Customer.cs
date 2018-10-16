using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MyWebApi.Models
{
    public  class Customer
    {
        [Required]
        public int? Id{get;set;}
        [Required]
        public string Name{get;set;}
    }
}