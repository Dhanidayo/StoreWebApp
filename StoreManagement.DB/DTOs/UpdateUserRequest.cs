using System;
using System.Text;
using System.Collections.Generic;

namespace StoreManagement.DB
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}