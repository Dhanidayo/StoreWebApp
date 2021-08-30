using System;
using System.Text;
using System.Collections.Generic;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class StorePatchRequest
    {
        public string StoreName { get; set; }
        public int Products { get; set; }
        public string Location { get; set; }
        public int Branches { get; set; }
    }
}
