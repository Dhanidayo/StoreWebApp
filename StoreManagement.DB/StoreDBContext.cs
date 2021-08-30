using System;
using System.Text;
using System.Collections.Generic;
using StoreManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StoreManagement.DB
{
    public class StoreDBContext : IdentityDbContext<User>
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options): base(options)
        {

        }

        //Creating tables for the following classes using EFCore
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}




///<summary>
    //the dbcontext class inheriting from identitydbcontext with a generic parameter of our user class in the models class.
    
    //creating a constructor and passing in the dbcontext options inorder to inject the dbcontext during Dependency injection
    //chaining the constructor with the base IentityDBContext base class
///</summary>
