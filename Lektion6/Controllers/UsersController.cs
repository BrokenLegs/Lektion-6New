using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion6.Models.Entities;
using Lektion6.Models.Repositories;
using Lektion6.ViewModels;

namespace Lektion6.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            List<User> users = Repository.Instance.GetSortedUsers(10, 0);
            ViewBag.Users = users;

            return View();
        }

        //
        // GET: /Details/
        public ActionResult Details(string id)
        {
            UserDetailsViewModel vm = new UserDetailsViewModel();
            vm.User = Repository.Instance.GetUserByUserName(id);
            vm.Posts = Repository.Instance.GetLatestPostForUser(vm.User.ID, 5);
            return View(vm);
        }

        //
        // GET: /Create/
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Create/
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (user.Validate())
            {
                Repository.Instance.Save<User>(user);

                return RedirectToAction("Index", "Users");
            }

            return View();
        }
    }
}
