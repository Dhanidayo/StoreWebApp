using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    public class Product
    {
        [Required]
        public string StoreId { get; set; }
        [Required]
        public string ProductId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }

        //Navigational Property
        public Store Store { get; set; }
    }
}