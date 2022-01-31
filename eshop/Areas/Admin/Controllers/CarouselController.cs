using System;
using System.Linq;
using System.Threading.Tasks;
using eshop.Models;
using eshop.Models.Database;
using eshop.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eshop.Areas.Admin.Controllers
{
    [Area("Admin")]     // Area has to be specified like this
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]         // just admin and manager have authorization to Carousel
    public class CarouselController : Controller
    {
        IHostingEnvironment Env;
        readonly EshopDBContext EshopDBContext;

        public CarouselController(EshopDBContext eshopDBContext, IHostingEnvironment env)
        {
            this.EshopDBContext = eshopDBContext;
            this.Env = env;
        }


        public async Task<IActionResult> Select()       // View has to have same name
        {
            CarouselViewModel carousel = new CarouselViewModel();
            carousel.Carousels = await EshopDBContext.Carousels.ToListAsync();
            return View(carousel);
        }


        public IActionResult Create()
        {
            return View();      // link to Create
        }

        [HttpPost]
        public async Task<IActionResult> Create(Carousel carousel)  // async method has to be defined as "Task<>"
        {
            if (ModelState.IsValid)
            {
                carousel.ImageSrc = String.Empty;

                FileUpload fileUpload = new FileUpload(Env.WebRootPath, "Carousels", "image");
                carousel.ImageSrc = await fileUpload.FileUploadAsync(carousel.Image);

                EshopDBContext.Carousels.Add(carousel);
                await EshopDBContext.SaveChangesAsync();

                return RedirectToAction(nameof(Select));    
            }
            else
            {
                return View(carousel);
            }
        }


        public IActionResult Edit(int id)
        {
            Carousel carouselItem = EshopDBContext.Carousels.Where(carI => carI.ID == id).FirstOrDefault();
            if (carouselItem != null)
            {
                return View(carouselItem);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Carousel carousel)
        {
            Carousel carouselItem = EshopDBContext.Carousels.Where(carI => carI.ID == carousel.ID).FirstOrDefault();

            if (carouselItem != null)
            {
                carouselItem.DataTarget = carousel.DataTarget;
                carouselItem.ImageAlt = carousel.ImageAlt;
                carouselItem.CarouselContent = carousel.CarouselContent;

                FileUpload fileUpload = new FileUpload(Env.WebRootPath, "Carousels", "image");
                if (String.IsNullOrWhiteSpace(carousel.ImageSrc = await fileUpload.FileUploadAsync(carousel.Image)) == false)
                {
                    carouselItem.ImageSrc = carousel.ImageSrc;
                }

                await EshopDBContext.SaveChangesAsync();

                return RedirectToAction(nameof(Select));    
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Carousel carouselItem = EshopDBContext.Carousels.Where(carI => carI.ID == id).FirstOrDefault();
            if (carouselItem != null)
            {
                EshopDBContext.Carousels.Remove(carouselItem);
                await EshopDBContext.SaveChangesAsync();

                return RedirectToAction(nameof(Select));        
            }
            else
            {
                return NotFound();
            }
        }

    }
}
