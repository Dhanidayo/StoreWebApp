using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class AddProductRequest
    {
        [Required]
        public string StoreId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}