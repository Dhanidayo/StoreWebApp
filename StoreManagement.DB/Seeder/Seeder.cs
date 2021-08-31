using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using StoreManagement.Models;
using Newtonsoft.Json;

namespace StoreManagement.DB
{
    public class Seeder
    {
        public async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, StoreDBContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Users.Any())
            {
                List<string> roles = new List<string> { "Admin", "Regular" };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role});
                }

                string data = await File.ReadAllTextAsync(@"C:\Users\lenovo\Dropbox\My PC (DESKTOP-0CQ3F2P)\Documents\StoreWebApp\StoreManagement.DB\Seeder\Users.json");
                List<User> users = JsonConvert.DeserializeObject<List<User>>(data);

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "P@ssw0rd1");
                    if (user == users[0])
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "Regular");
                    }
                }
            }

            if (!context.Stores.Any())
            {
                string data = await File.ReadAllTextAsync(@"C:\Users\lenovo\Dropbox\My PC (DESKTOP-0CQ3F2P)\Documents\StoreWebApp\StoreManagement.DB\Seeder\Stores.json");
                
                List<Store> stores = JsonConvert.DeserializeObject<List<Store>>(data);

                await context.Stores.AddRangeAsync(stores);

                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                string data = await File.ReadAllTextAsync(@"C:\Users\lenovo\Dropbox\My PC (DESKTOP-0CQ3F2P)\Documents\StoreWebApp\StoreManagement.DB\Seeder\Products.json");
                
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(data);

                await context.Products.AddRangeAsync(products);

                await context.SaveChangesAsync();
            }
        }
    }
}