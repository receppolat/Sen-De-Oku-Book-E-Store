using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using SenDeOku.Entities;
using SenDeOku.Identity;
using SenDeOku.Models;

namespace SenDeOku.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;
        private RoleManager<AppIdentityRole> _roleManager;
        private readonly OfficeContext _officeContext;

        public UserController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, OfficeContext officeContext, RoleManager<AppIdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _officeContext = officeContext;
            _roleManager = roleManager;
        }
        //Role oluşturma
        /*public async Task<IActionResult> createRole()
        {
            var result = await _roleManager.CreateAsync(new AppIdentityRole { 
                Name = "Kullanici"
            });
            var result2 = await _roleManager.CreateAsync(new AppIdentityRole
            {
                Name = "Yonetici"
            });
            return View();
        }*/
        //Personel
        /*
       public async Task<IActionResult> createAdmin()
       {
           var user = new AppIdentityUser
           {
               UserName = "Admin",
               Email = "sendeokur@gmail.com"
           };
           var result = await _userManager.CreateAsync(user, "Admin123.");
           if (result.Succeeded)
           {
               var result2 = await _userManager.AddToRoleAsync(user, "Yonetici");
               return RedirectToAction("Login", "Kullanici");

           }
           return View();
       }*/
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(String.Empty, "Email onayı gerekli..");
                    return RedirectToAction("Login", "Kullanici", model);
                }
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Account", "User", user.Id);
                }
            }
            ModelState.AddModelError(String.Empty, "Kullanıcı adı/parola yanlış!");
            return RedirectToAction("Login", "Kullanici", model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "Kullanici", model);
            }
            if (model.ConfirmPassword != model.Password)
            {
                ModelState.AddModelError(String.Empty, "Parolalar uyuşmuyor!");
                return RedirectToAction("Login", "Kullanici", model);
            }
            var name = await _userManager.FindByNameAsync(model.UserName);
            if (name != null)
            {
                ModelState.AddModelError(String.Empty, "Bu kullanıcı adı daha önce alınmış.");
                return RedirectToAction("Login", "Kullanici", model);
            }
            var user = new AppIdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(user, "Kullanici");
                _officeContext.Customers.Add(new Customer
                {
                    CustomerID = user.Id
                });
                _officeContext.SaveChanges();
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);

                var callBackUrl = Url.Action("ConfirmEmail", "User", new { userID = user.Id, code = confirmationCode.Result });
                /*Email*/
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Email onayı", "testyazilimhesabi@gmail.com"));
                message.To.Add(new MailboxAddress("Email onayı", user.Email));
                message.Subject = "Gostie e-mail onayı";
                message.Body = new TextPart("plain")
                {
                    Text = "Giriş yapabilmek için email onayı gerekmekte. Aşağıdaki linkten yapabilirsiniz;\n " + callBackUrl
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("yazilimtesthesabi@gmail.com", "yazilim1998");
                    client.Send(message);
                    client.Disconnect(true);
                }
                /*Email*/
                return RedirectToAction("Login", "Kullanici");

            }
            ModelState.AddModelError(String.Empty, "Parolanız bir büyük harf, bir işaret(.,!*) ve bir rakam içermelidir.");

            return RedirectToAction("Login", "Kullanici", model);
        }
        public async Task<IActionResult> ConfirmEmail(string userID, string code)
        {
            if (userID == null || code == null)
            {
                return RedirectToAction("Login", "Kullanici");//hata
            }
            var user = await _userManager.FindByIdAsync(userID);
            if (user == null)
            {
                throw new ApplicationException("Kullanıcı bulunamadı..");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Kullanici");//Doğru durum
            }
            return RedirectToAction("Login", "Kullanici");//hata
        }
        [Authorize(Roles = "Kullanici")]
        public async Task<IActionResult> Account()
        {
            List<Category> categories = (from Category in _officeContext.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;
            ViewData["Name"] = "Hesabım | Sen De Oku";

            var customer = from cus in _officeContext.Customers
                           where cus.CustomerID == User.FindFirstValue(ClaimTypes.NameIdentifier)
                           select cus;
            Customer newCustomer = customer.FirstOrDefault();
            if (newCustomer.CustomerID == null)
            {
                return NotFound();
            }
            List<City> cityResult = (from city in _officeContext.Cities
                                     select city).ToList<City>();
            CustomerUpdateModel customerUpdateModel = new CustomerUpdateModel
            {
                Customer = newCustomer,
                City = new SelectList(cityResult, "CityID", "Name")
            };
            return View(customerUpdateModel);

        }
        [Authorize(Roles = "Kullanici")]
        [HttpPost]
        public async Task<IActionResult> Account(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            Customer newCustomer = _officeContext.Customers.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));
            newCustomer.Name = customer.Name;
            newCustomer.Surname = customer.Surname;
            newCustomer.Cell = customer.Cell;
            newCustomer.Adress = customer.Adress;
            newCustomer.CardNumber = customer.CardNumber;
            newCustomer.City = _officeContext.Cities.Find(customer.City.CityID);
            _officeContext.SaveChanges();
            return RedirectToAction("Account", "User");
        }
        [Authorize(Roles = "Kullanici")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Kullanici");
        }
    }
}

//sepetekle-silme++//jskaldı
//hesap düzenleme++
//hesap=>siparişler 
//shipper ekle veri tabanına