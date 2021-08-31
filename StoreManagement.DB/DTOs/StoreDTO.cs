using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class StoreDTO
    {
        public string StoreId { get; set; }
        public string UserId { get; set; }
        public string StoreName { get; set; }
        public string StoreType { get; set; }
        public string Location { get; set; }
        public int Branches { get; set; }
    }
}
