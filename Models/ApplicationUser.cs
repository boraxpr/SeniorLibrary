using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorLibrary.Models
{
    //IdentityUser is aspNet default user
    //Because Aj. requested these attributes so ApplicationUser extends from IdentityUser
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentID { get; set; }
    }
}
