using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Webapplication.Models;

namespace Webapplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Create()
    {
        TempData["Message"]= "Sign in to your account to apply for Reimbursement";
        return RedirectToAction("LoginPage","Login");
    }
    // [HttpPost]
    // public IActionResult Create(Employee employee)
    
    // {
    //     Repository.Create(employee);
    //     return View("Thanks", employee);
    // } 
    
    // public IActionResult ViewDetails(Employee employee)
    // {
    //     return View(Repository.AllEmployees);
    // }
     public IActionResult Privacy()
     {
        return View();
     }
    // [HttpGet]
    // public IActionResult Delete()
    // {
    //     return View();
    // }
    // [HttpPost]
    // public IActionResult Delete(Employee employee)
    // {
    //     Repository.Delete(employee);
    //     return View("Deleted", employee);
    // }
    // [HttpGet]
    // public IActionResult Update()
    // {
    //     return View();
    // }
    // [HttpPost]
    // public IActionResult Update(Employee employee)
    // {
    //     Repository.Update(employee);
    //     return View("Updated", employee);
    // }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
