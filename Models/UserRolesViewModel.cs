using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorLibrary.Models
{
    //Used in Pages/UserRoles
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentID { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
