using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedOff.ViewModels
{
    public class RegisterViewModel
    {
        [Required] 
        [MinLength(2, ErrorMessage ="First name too short, min 2 characters")] 
        [MaxLength(20, ErrorMessage ="First name too long, max 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="Last name too short, min 2 characters")]
        [MaxLength(20, ErrorMessage ="Last name too long, max 20 characters")]
        public string LastName{ get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage ="Password too short, in 8 characters")]
        [MaxLength(25, ErrorMessage="Password too long, max 25 characters")]
        public string Password { get; set; }
    }
}
