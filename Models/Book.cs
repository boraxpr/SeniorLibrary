using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorLibrary.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public byte[] DataFiles { get; set; }
        public DateTime CreatedOn { get; set; }
        // For ROLE Lecturer to filter out entries in Pages/Requests/Index.cshtml
        // The filter logic is in view (cshtml.cs) Pages/Requests/Index.cshtml
        public string Advisor { get; set; }
        // Tracking download count
        public int downloadCount { get; set; }
    }
}
