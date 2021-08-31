using System;
using System.Text;
using System.Collections.Generic;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class UpdateProductRequest
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}