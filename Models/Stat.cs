using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeniorLibrary.Models
{
    public class Stat
    {
        [Key]
        public int ID { get; set; }
        public string userName { get; set; }
        public string DownloadedBooks { get; set; }
    }
}