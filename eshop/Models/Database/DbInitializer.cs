using eshop.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models.Database
{
    public class DbInitializer
    {
        public static void Initialize(EshopDBContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Carousels.Count() == 0)
            {
                IList<Carousel> carousels = CarouselHelper.GenerateCarousel();
                foreach (var item in carousels)
                {
                    dbContext.Carousels.Add(item);
                }

                dbContext.SaveChanges();
            }

            if (dbContext.Products.Count() == 0)
            {
                IList<Product> products = ProductHelper.GenerateProducts();
                foreach (var item in products)
                    dbContext.Products.Add(item);

                dbContext.SaveChanges();
            }

        }

        public static async void EnsureRoleCreatedAsync(IServiceProvider serviceProvider)
        {
            using (var services = serviceProvider.CreateScope())
            {
                RoleManager<Role> roleManager = services.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                string[] roles = Enum.GetNames(typeof(Roles));      // get all items from enum Roles

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new Role(role));
                }
            }
        }


        public static async void EnsureAdminCreatedAsync(IServiceProvider serviceProvider)
        {
            using (var services = serviceProvider.CreateScope())
            {
                UserManager<User> userManager = services.ServiceProvider.GetRequiredService<UserManager<User>>();

                User admin = new User()
                {
                    UserName = "admin",
                    Email = "admin@utb.cz",
                    Name = "Jan",
                    LastName = "Bureš",
                    EmailConfirmed = true
                };


                var password = "abcd";

                User adminInDatabase = await userManager.FindByNameAsync(admin.UserName);      // find some admin if existed

                if (adminInDatabase == null)                                                    // if amdin does not exist
                {
                    IdentityResult iResult = await userManager.CreateAsync(admin, password);    // try to add new admin

                    if (iResult.Succeeded)
                    {
                        string[] roles = Enum.GetNames(typeof(Roles));      // get all items from enum Roles

                        foreach (var role in roles)
                        {
                            await userManager.AddToRoleAsync(admin, role);
                        }
                    }
                    else if (iResult.Errors != null && iResult.Errors.Count() > 0)
                    {
                        foreach (var error in iResult.Errors)
                        {
                            Debug.WriteLine("Error during role Creation: " + error.Code + " -> " + error.Description);      // log errors
                        }
                    }
                }



                // add manager to database
                User manager = new User()
                {
                    UserName = "manager",
                    Email = "manager@utb.cz",
                    Name = "Jan",
                    LastName = "Bureš",
                    EmailConfirmed = true
                };

                User managerInDatabase = await userManager.FindByNameAsync(manager.UserName);      // find some manager if existed

                if (managerInDatabase == null)                                                    // if manager does not exist
                {
                    IdentityResult iResult = await userManager.CreateAsync(manager, password);    // try to add new manager

                    if (iResult.Succeeded)
                    {
                        string[] roles = Enum.GetNames(typeof(Roles));      // get all items from enum Roles

                        foreach (var role in roles)
                        {
                            if (role != Roles.Admin.ToString())             // if roles is not admin
                            {
                                await userManager.AddToRoleAsync(manager, role);
                            }
                        }
                    }
                    else if (iResult.Errors != null && iResult.Errors.Count() > 0)
                    {
                        foreach (var error in iResult.Errors)
                        {
                            Debug.WriteLine("Error during role Creation: " + error.Code + " -> " + error.Description);      // log errors
                        }
                    }
                }


            }
        }

    }
}
