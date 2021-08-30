using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class StorePutRequest
    {
        [Required]
        public string StoreName { get; set; }
        [Required]
        public int Products { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Branches { get; set; }
    }
}
