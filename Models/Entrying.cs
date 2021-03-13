using System;
using System.ComponentModel.DataAnnotations;

namespace SeniorLibrary.Models
{
    public class Entrying
    {        
        [Key]
        public int ID { get; set; }
        public string SubmittorEmail {get; set;}
        public string ProjectName { get; set; }
        public string Category { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubmittedDate {get; set;}
    }
}