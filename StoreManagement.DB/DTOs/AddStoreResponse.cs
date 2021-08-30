using System;
using System.Text;
using System.Collections.Generic;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class AddStoreResponse
    {
        public string StoreId { get; set; }
        public string UserId { get; set; }
        public string StoreName { get; set; }
        public int Products { get; set; }
        public string Location { get; set; }
        public int Branches { get; set; }
    }
}
