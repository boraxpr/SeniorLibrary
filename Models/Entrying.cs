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
        //For approve-download logic (Lecturer approve then Student can download)
        public string BookAdvisor { get; set; }
        //For approve-download logic
        public Boolean Downloadable { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubmittedDate {get; set;}
    }
}