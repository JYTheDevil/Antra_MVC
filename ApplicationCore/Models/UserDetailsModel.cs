using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserDetailsModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string? PhoneNum { get; set; }
        public DateTime? DateOfBirth { get; set; }
        

    }
}