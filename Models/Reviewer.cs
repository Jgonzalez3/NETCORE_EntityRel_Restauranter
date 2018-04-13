using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace RESTauranter.Models{
    public class Reviewer{
        public int Id {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public string Restaurant {get;set;}
        [Required]
        [MinLength(10)]
        public string Review {get;set;}
        [Required]
        public int Rating {get;set;}
        // DateTime date =  DateTime.Now;
        // date.ToString();
        [Required]
        [DataType(DataType.DateTime)]
        // [Range(typeof(DateTime), "1/1/1900", ]
        public DateTime VisitDate {get;set;}
        
    }
}