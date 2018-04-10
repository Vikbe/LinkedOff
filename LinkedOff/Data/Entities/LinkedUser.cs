using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.Data.Entities
{
    public class LinkedUser : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Experience> UserExperience { get; set; } 
        public ICollection<LinkedUser> Connections { get; set; }
        public ICollection<Timeline> StatusUpdates { get; set; }
    }
}
