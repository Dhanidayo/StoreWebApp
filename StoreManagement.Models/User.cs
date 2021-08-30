using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace StoreManagement.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
