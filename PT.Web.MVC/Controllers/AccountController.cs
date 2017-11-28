using Microsoft.AspNet.Identity;
using PT.BL.AccountRepository;
using PT.BL.Settings;
using PT.Entity.IdentityModel;
using PT.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PT.Web.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userManager = MemberShipTools.NewUserManager();
            var checkUser = userManager.FindByName(model.Username);

            if (checkUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu kullanıcı zaten kayıtlı!");
                return View(model);
            }

            var activationCod = Guid.NewGuid().ToString();
            ApplicationUser user = new ApplicationUser()
            {
                Name = model.Name,
                Surname=model.Surname,
                Email=model.Email,
                UserName=model.Username,
                ActivationCode=activationCod
            };

            var response = userManager.Create(user, model.Password);

            if (response.Succeeded)
            {
                string siteURL = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

                if (userManager.Users.Count()==1)
                {
                    userManager.AddToRole(user.Id, "Admin");
                    await SiteSettings.SendMail(new MailModel
                    {
                        To = user.Email,
                        Subject = "Hoşgeldin Sahip",
                        Message = "Sitemizi yöneteceğin için çok mutluyuz ^_^"
                    });
                }
                else
                {
                    userManager.AddToRole(user.Id, "Passive");
                    await SiteSettings.SendMail(new MailModel
                    {
                        To = user.Email,
                        Subject = "Hoşgeldin Sahip",
                        Message = $"Merhaba {user.Name} {user.Surname}<br/>Sistemi Kulanabilmeniz için <a href='{siteURL}/Account/Activation?code={activationCod}'>Aktivasyon Kodu</a>"

                    });
                }
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kayıt işleminde bir hata oluştu");
                return View(model);
            }
        }
    }
}