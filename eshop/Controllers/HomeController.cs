using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eshop.Models;
using eshop.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using eshop.Models.Identity;

namespace eshop.Controllers
{
    public class HomeController : Controller
    {
        readonly EshopDBContext EshopDBContext;

        readonly ILogger<HomeController> logger;

        public HomeController(EshopDBContext eshopDBContext, ILogger<HomeController> logger)
        {
            this.EshopDBContext = eshopDBContext;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ItemViewModel itemViewModel = new ItemViewModel();
            itemViewModel.Carousels = await EshopDBContext.Carousels.ToListAsync();       
            itemViewModel.Products = await EshopDBContext.Products.ToListAsync();       

            return View(itemViewModel);                
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            throw new Exception("Something happened");

            //return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(Exception e)
        {
            var featureException = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError("Exception occured: " + featureException.Error.ToString() + Environment.NewLine + "Exception Path: " + featureException.Path);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult ErrorCodeStatus(int? statusCode = null)
        {
            string originalUrl = String.Empty;
            var features = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            if (features != null)
            {
                originalUrl = features.OriginalPathBase + features.OriginalPath + features.OriginalQueryString;
            }

            var statCode = statusCode.HasValue ? statusCode.Value : 0;

            logger.LogWarning("Status Code:" + statCode + "Original URL: " + originalUrl);

            if (statCode == 404)
            {
                _404ViewModel vm404 = new _404ViewModel()
                {
                    StatusCode = statCode,
                };

                return View(statusCode.ToString(), vm404);
            }

            if (statCode == 400)
            {
                ErrorCodeStatusViewModel vm400 = new ErrorCodeStatusViewModel()
                {
                    StatusCode = statCode,
                    OriginalURL = originalUrl,
                };

                return View(statusCode.ToString(), vm400);
            }


            ErrorCodeStatusViewModel vm = new ErrorCodeStatusViewModel()
            {
                StatusCode = statCode,
                OriginalURL = originalUrl
            };

            return View(vm);
        }


        public IActionResult Detail(int id)
        {
            Product productItem = EshopDBContext.Products.Where(prodId => prodId.ID == id).FirstOrDefault();
            if (productItem != null)
            {
                return View(productItem);
            }
            else
            {
                return NotFound();
            }
        }


        //[HttpPost]
        public async Task<IActionResult> Guard(Product product)
        {
            GuardingDog guardingDogNew = new GuardingDog();
            guardingDogNew.ProductID = product.ID;

            User userID = EshopDBContext.User.Where(user => user.UserName == User.Identity.Name).FirstOrDefault();
            guardingDogNew.UserID = userID.Id;

            GuardingDog guardingDogOld = EshopDBContext.GuardingDogs.Where(gd => gd.UserID == guardingDogNew.UserID)
                                                                    .Where(gd => gd.ProductID == guardingDogNew.ProductID).FirstOrDefault();

            if (guardingDogOld == null)
            {
                EshopDBContext.GuardingDogs.Add(guardingDogNew);
                await EshopDBContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
