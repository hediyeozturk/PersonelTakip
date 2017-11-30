using Microsoft.AspNet.Identity;
using PT.BL.AccountRepository;
using PT.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PT.Web.MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var userManager = MemberShipTools.NewUserManager();
            var users = userManager.Users.Select(x => new UsersViewModel
            {
                UserId = x.Id,
                Email = x.Email,
                Name = x.Name,
                Surname = x.Surname,
                UserName = x.UserName,
                Salary = x.Salary,
                RegisterDate = x.RegisterDate,
                RoleId = x.Roles.FirstOrDefault().RoleId,
                RoleName = MemberShipTools.NewRoleManager().FindById(x.Roles.FirstOrDefault().RoleId).Name
            }).ToList();
            var roles = MemberShipTools.NewRoleManager().Roles.ToList();
            List<SelectListItem> RoleList = new List<SelectListItem>();
            roles.ForEach(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id
            });
            ViewBag.roles = RoleList;
            return View(users);
        }
    }
}