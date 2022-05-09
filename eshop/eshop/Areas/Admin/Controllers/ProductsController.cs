using eshop.Controllers;
using eshop.Models;
using eshop.Models.Database;
using eshop.Models.Identity;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class ProductsController : Controller
    {
        IHostingEnvironment Env;
        private readonly EshopDBContext _context;
        readonly ILogger<HomeController> logger;

        public ProductsController(EshopDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }


        // return view
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)  // async method has to be defined as "Task<>"
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            logger.LogInformation("New product added " + product.Name + ". Content: " + product.Content + ", price: " + product.Price + ", availability: " + product.Available);

            return RedirectToAction(nameof(Index));    // back to Product Index page
        }


        //[HttpPost]
        //public async Task<IActionResult> Create(Product product)  // async method has to be defined as "Task<>"
        //{
        //    if (ModelState.IsValid)
        //    {
        //        product.ImageSrc = String.Empty;

        //        FileUpload fileUpload = new FileUpload(Env.WebRootPath, "Products", "image");
        //        product.ImageSrc = await fileUpload.FileUploadAsync(product.Image);

        //        _context.Products.Add(product);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));    // back to Select all
        //    }
        //    else
        //    {
        //        return View(product);
        //    }
        //}


        public IActionResult Edit(int id)
        {
            Product productItem = _context.Products.Where(prodId => prodId.ID == id).FirstOrDefault();

            if (productItem != null)
            {
                return View(productItem);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            Product productItem = _context.Products.Where(prodId => prodId.ID == product.ID).FirstOrDefault();

            int oldPrice = productItem.Price;
            bool oldAvailibility = productItem.Available;

            // check if there 
            if (productItem != null)
            {
                productItem.Name = product.Name;
                productItem.Content = product.Content;
                productItem.Price = product.Price;
                productItem.Available = product.Available;

                //FileUpload fileUpload = new FileUpload(Env.WebRootPath, "Products", "image");
                //if (String.IsNullOrWhiteSpace(product.ImageSrc = await fileUpload.FileUploadAsync(product.Image)) == false)
                //{
                //    productItem.ImageSrc = product.ImageSrc;
                //}

                await _context.SaveChangesAsync();

                logger.LogInformation("Product " + product.Name + "was edited. Content: " + product.Content + ", price: " + product.Price + ", availability: " + product.Available);

                // check if there was change in price or availability
                if (productItem.Price != oldPrice || productItem.Available != oldAvailibility)
                {
                    // check Product in GuardingDog table 
                    //GuardingDog guarding = _context.GuardingDogs.Where(gd => gd.ProductID == productItem.Name).FirstOrDefault();

                    var gdGuardedItem = _context.GuardingDogs.Include(gd => gd.Product)
                                                      .Include(gd => gd.User)
                                                      .Where(gd => gd.ProductID == product.ID);

                    var gdList = gdGuardedItem.ToList();

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Bury eshop", "burdy8910@gmail.com"));
                    message.Subject = $"Your guarded item: {productItem.Name} was changed";

                    if (productItem.Available)
                    {
                        message.Body = new TextPart("plain")
                        {
                            Text = $"Your guarded item: {productItem.Name} on Bury eshop was changed! It now costs only {productItem.Price},-CZK and it is currently available!"
                        };
                    }
                    else
                    {
                        message.Body = new TextPart("plain")
                        {
                            Text = $"Your guarded item: {productItem.Name} on Bury eshop was changed! It now costs only {productItem.Price},-CZK but it is currently not available."
                        };
                    }


                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("burdy8910@gmail.com", "EshopPWT2021");

                        for (int i = 0; i < gdList.Count(); i++)
                        {
                            message.To.Add(new MailboxAddress(gdList[i].User.Name, gdList[i].User.Email));
                            client.Send(message);
                            logger.LogInformation("Email about guarded item: " + product.Name + "was send to: " + gdList[i].User.Name + "to the email: " + gdList[i].User.Name);
                        }

                        client.Disconnect(true);
                    }

                }


                return RedirectToAction(nameof(Index));    // back to Product review
            }
            else
            {
                return NotFound();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            Product productItem = _context.Products.Where(prodI => prodI.ID == id).FirstOrDefault();
            if (productItem != null)
            {
                _context.Products.Remove(productItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));        // we wanna return all items (except of just deleted)
            }
            else
            {
                return NotFound();
            }
        }



    }
}
