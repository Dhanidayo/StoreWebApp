using System;
using System.Text;
using System.Collections.Generic;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class GetProductResponse
    {
        public string StoreId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        //Navigational Properties
        public Store Store { get; set; }
    }
}