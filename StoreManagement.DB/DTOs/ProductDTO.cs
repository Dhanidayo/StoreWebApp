using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class ProductDTO
    {
        public string StoreId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
