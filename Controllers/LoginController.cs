using Microsoft.AspNetCore.Mvc;
using Webapplication.Models;
//using Session_State.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Webapplication.Controllers
{
    // SqlConnection sqlconnection = new SqlConnection("data source=ASPIRE1443;database=MVCAplication;integrated security=SSPI;");
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(SignupAccount signupaccount)
        {
            if(Validation.validateDetails(signupaccount)==1)
            {
                return RedirectToAction("Index","Home");
            }
            else if(Validation.validateDetails(signupaccount)==2)
            {
                ViewBag.Message="Password doesnot match";
                return View("Signup");
            }
            else if(Validation.validateDetails(signupaccount)==3)
            {
                ViewBag.Message="Invalid Username or Password";
                return View("Signup");
            }

            else if(Validation.validateDetails(signupaccount)==4)
            {
                ViewBag.Message="Invalid ID";
                return View("Signup");
            }
            else if(Validation.validateDetails(signupaccount)==5)
            {
                ViewBag.Message="User already exists";
                return View("Signup");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult LoginPage()
        {
            HttpContext.Session.SetString("Session","");
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(Account account) 
        {
            if(Validation.validateLogin(account)==1)
            {
                HttpContext.Session.SetString("Session",account.EmployeeID);
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.AutoFlush=true;
                Trace.WriteLine("Logged in successfully");
                return RedirectPreserveMethod("~/Employee/Index");
                
            }
            else if(Validation.validateLogin(account)==2)
            {
                ViewBag.Message="Username or Password is invalid";
                return View("LoginPage");
            }
            else if(Validation.validateLogin(account)==3)
            {
                ViewBag.Message="User doesnot exists";
                return View("LoginPage");
            }
            else if(Validation.validateLogin(account)==4)
            {
                HttpContext.Session.SetString("Session",account.EmployeeID);
                return RedirectToAction("Home","Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Forgotpassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Forgotpassword(ForgotPassword forgotPassword)
        {
            if(ModelState.IsValid)
            {
                if(Validation.changePassword(forgotPassword)==1)
                 return View("Thanks");
                else if(Validation.changePassword(forgotPassword)==2)
                {
                    ViewBag.Message="User doesot exists";
                    return View("Forgotpassword");
                } 
            }
            return View();
        }
    }
}