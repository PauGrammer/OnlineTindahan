using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineTindahan.Models;
namespace OnlineTindahan.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("AllUsers", "Users");
        }

        public ActionResult AllUsers()
        {
            var users = new List<User>();

            users.Add(new User() { UserID = 1, FirstName = "Paulo", LastName = "Anoza", EmailAddress = "pau.anoza28@gmail.com", Password = "d08EA28t9h5" });
            users.Add(new User() { UserID = 2, FirstName = "Camille", LastName = "Francisco", EmailAddress = "cjef15@gmail.com", Password = "ccccjjjjj" });
            users.Add(new User() { UserID = 3, FirstName = "Luffy", LastName = "Monkey", EmailAddress = "pirateKing@gmail.com", Password = "onepiece" });

            return View(users);
        }

        
        public ActionResult Details(User user)
        {
            return View(user);
        }
    }
}