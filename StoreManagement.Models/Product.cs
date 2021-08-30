using System;

namespace StoreManagement.Models
{
    public class Product
    {
        public string ProductId { get; set; } = Guid.NewGuid().ToString();
        public string ProductName { get; set; }
        public string StoreId { get; set; }

        //Navigational Property
        public Store Store { get; set; }
    }
}