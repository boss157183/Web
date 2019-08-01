using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SignUp()
        {
            ViewBag.Message = "SignUp";
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpModel GetData)
        {
            WebAppDBEntities db = new WebAppDBEntities();
            var userDatails = db.Accesses.Where(x => x.Username == GetData.UserName).FirstOrDefault();
            if (userDatails == null)                
            {   
                Access GetAccess = new Access
                {
                    Username = GetData.UserName,
                    Password = GetData.Password
                };
                Person GetPerson = new Person
                {
                    FirstName = GetData.FirstName,
                    LastName = GetData.LastName,
                    EmailAddress = GetData.EmailAddress,
                    Phone = GetData.Phone,
                    Username = GetData.UserName
                };
                db.Accesses.Add(GetAccess);
                db.People.Add(GetPerson);
                db.SaveChanges();
                return RedirectToAction("LogIn", "Home");
            }
            else
            {
                GetData.SignUpError = "UserName already exists.";
                return View("SignUp",GetData);
            }
        }
        public ActionResult LogIn()
        {
            ViewBag.Message = "LogIn";
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Access DataAccess)
        {
            WebAppDBEntities db = new WebAppDBEntities();
            var userDetails = db.Accesses.Where(x => x.Username == DataAccess.Username && x.Password == DataAccess.Password).FirstOrDefault();
            if (userDetails == null)
            {
               DataAccess.LoginError = "Wrong Username or Password,";
                return View("LogIn",DataAccess);
            }
            else
            {
                var PeopleDetails = db.People.Where(x => x.Username == DataAccess.Username).FirstOrDefault();
                Session["Id"] = PeopleDetails.Id;
                Session["Username"] = PeopleDetails.Username;
                Session["FirstName"] = PeopleDetails.FirstName;
                Session["LastName"] = PeopleDetails.LastName;
                return RedirectToAction("Index", "User");
            }
        }
        public ActionResult Logout()
        {
            int UserID = (int)Session["Id"];
            Session.Abandon();
            return RedirectToAction("LogIn", "Home");
        }
    }
}