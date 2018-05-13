using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplesOrdering.Models;
using System.Web.Mvc;
using ApplesOrdering.DAL;



namespace ApplesOrdering.Controllers
{
    public class HomeController : Controller
    {
        private const int Register = 0;
        private const int Login = 1;

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult LoginRegister()
        {

            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                UserInfoModel model = new UserInfoModel();
                return View("LoginRegister", model);
            }
           
        }

        [HttpPost]
        public ActionResult LoginRegister(UserInfoModel newUser, int logCode)
        {

            UserInfoDAL userInfoDAL = new UserInfoDAL();

            if (logCode == Register)
            {
                if (ModelState.IsValid)
                {


                    userInfoDAL.SaveNewUser(newUser);
                    var user = userInfoDAL.SelectUserByEmail(newUser.Email);
                    Session["User"] = user;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("LoginRegister");
                }
            }
            if (logCode == Login)
            {
                string providedPassword = newUser.Password;

                if (userInfoDAL.CheckAvailability(newUser.Email) == false)
                {
                    UserInfoModel user = userInfoDAL.SelectUserByEmail(newUser.Email);

                    if (user.Password == providedPassword)
                    {
                        Session["User"] = user;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.LoginError = "Login or password was incorrect.";
                }
            }
            return View("LoginRegister");
        }

        public ActionResult Orders()
        {

            return View("Orders");
        }
    }
}