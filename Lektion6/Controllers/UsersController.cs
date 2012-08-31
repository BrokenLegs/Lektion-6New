using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion6.Models.Entities;
using Lektion6.Models.Repositories;

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

    }
}
