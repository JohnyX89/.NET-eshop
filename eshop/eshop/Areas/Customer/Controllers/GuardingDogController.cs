using System.Linq;
using System.Threading.Tasks;
using eshop.Controllers;
using eshop.Models;
using eshop.Models.Database;
using eshop.Models.Identity;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace eshop.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager) + ", " + nameof(Roles.Customer))]         // just for loged in users
    public class GuardingDogController : Controller
    {
        private readonly EshopDBContext _context;
        readonly ILogger<HomeController> logger;


        public GuardingDogController(EshopDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = _context.User.Where(user => user.UserName == User.Identity.Name).FirstOrDefault();

            if (currentUser.UserName == "admin" || currentUser.UserName == "manager")
            {
                var allGuardedItems = _context.GuardingDogs.Include(gd => gd.Product).Include(gd => gd.User);

                return View(await allGuardedItems.ToListAsync());
            }

            var justUsers = _context.GuardingDogs.Include(gd => gd.Product).Include(gd => gd.User).Where(gd => gd.UserID == currentUser.Id);
            return View(await justUsers.ToListAsync());
        }


        //[HttpPost]
        //public async Task<IActionResult> Guard(GuardingDog guardingDog)
        //{
        //    GuardingDog guardingDogItem = _context.GuardingDogs.Where(gd => gd.ID == guardingDog.ID).FirstOrDefault();

        //    if (guardingDogItem != null)
        //    {
        //        ModelState.AddModelError("Guard", "U are already guarding this item");
        //        return View();
        //    }

        //    _context.GuardingDogs.Add(guardingDogItem);
        //    await _context.SaveChangesAsync();

        //    return View();
        //}


        public async Task<IActionResult> Delete(int id)
        {
            GuardingDog guardingDogItem = _context.GuardingDogs.Include(gd => gd.User)
                                                               .Include(gd => gd.Product)
                                                               .Where(gd => gd.ID == id).FirstOrDefault();

            if (guardingDogItem != null)
            {

                _context.GuardingDogs.Remove(guardingDogItem);
                await _context.SaveChangesAsync();

                if (User.Identity.Name == "admin" || User.Identity.Name == "manager")
                {
                    // send notification to user
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Bury eshop", "burdy8910@gmail.com"));
                    message.Subject = $"Your guarded item: {guardingDogItem.Product.Name} was delete from your guarded items";

                    message.Body = new TextPart("plain")
                    {
                        Text = $"Your guarded item: {guardingDogItem.Product.Name} was delete from your guarding list!"
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("burdy8910@gmail.com", "EshopPWT2021");

                        message.To.Add(new MailboxAddress(guardingDogItem.User.Name, guardingDogItem.User.Email));
                        client.Send(message);
                        logger.LogInformation(guardingDogItem.Product.Name + "was delete from user's: " + guardingDogItem.User.Name + "guarding list");

                        client.Disconnect(true);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
