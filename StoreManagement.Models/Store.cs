using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    public class Store
    {
        [Required]
        public string StoreId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string UserId { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string StoreType { get; set; }
        [Required]
        public string Location { get; set; }
        public int Branches { get; set; }
        public int Products { get; set; }

        //Navigational Properties
        public User User { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}