using System.Diagnostics;
using System;
using Microsoft.AspNetCore.Mvc;
using Webapplication.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Webapplication.Data;
using Microsoft.Win32.SafeHandles;

namespace Webapplication.Controllers;
public class EmployeeController:Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _WebHostEnivernment;
    private SafeFileHandle serverFolder;

    public EmployeeController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
    {
        _db=db;
        _WebHostEnivernment = webHostEnvironment;
    }
    public IActionResult Index()
    {
        var createtablefromDb = _db.ReimbursementDetails.Where(s => s.EmployeeID == (HttpContext.Session.GetString("Session")));
        if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
            IEnumerable<Employees> employeedetailslist = (IEnumerable<Employees>) createtablefromDb;
            
        return View(employeedetailslist);
        }
        
        return RedirectToAction("LoginPage","Login");
    }
    [HttpGet]
    public IActionResult Create()
    {
        if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
        return View();
        }
        return RedirectToAction("LoginPage","Login");
    }
    [HttpPost]
    public async Task<IActionResult> Create(Employees employee)
    {
        if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
                if(Validation.validateForm(employee)==1)
                {
                    employee.Status="Pending";
                    employee.SubmittedDate=DateTime.Now;
                    if(employee.file!=null)
                    {
                        string wwwRootPath = _WebHostEnivernment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(employee.file.FileName);
                        string extension = Path.GetExtension(employee.file.FileName);
                        employee.Attachment = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string serverFoler = Path.Combine(wwwRootPath + "/Files/", fileName);
                        using( var fileStream = new FileStream(serverFolder, (FileAccess)FileMode.Create))
                        {
                            await employee.file.CopyToAsync(fileStream);
                        }
                    }
                        Repository.Create(employee);
                        _db.ReimbursementDetails.Add(employee);
                        await _db.SaveChangesAsync();
                        ViewBag.alert="Your form has been submitted";
                        return View("Status",employee);
                }
                else if(Validation.validateForm(employee)==2)
                {
                    ViewBag.Creates="Invalid name";
                    return View("Create",employee);
                }
        }
        return RedirectToAction("LoginPage","Login");
    } 
    [HttpGet]
    public IActionResult Status()
    {
         if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
        return View();
        }
        return RedirectToAction("LoginPage","Login");
    }
    [HttpGet]
    public IActionResult ViewDetails(Employees employee)
    {
        
       if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
            return View(Repository.AllEmployees);
        }
        
        return RedirectToAction("LoginPage","Login");
    }
    [HttpGet]
   public IActionResult Profile()
   {
    SignupAccount signupaccount =  Validation.myProfile(HttpContext.Session.GetString("Session"));
    
    if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
    {
        
    return View(signupaccount);
    }
    return RedirectToAction("LoginPage","Login");
   }
    [HttpGet]
    public IActionResult Ratings()
    {
         if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
        return View();
        }
        return RedirectToAction("LoginPage","Login");
    }
    [HttpPost]
    public IActionResult Ratings(Reviews reviews)
    {
         if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
          _db.RatingDetails.Add(reviews); 
          _db.SaveChanges(); 
          return View("Thanks",reviews);
        }
        return RedirectToAction("LoginPage","Login");
    }
    public IActionResult PendingForm()
    {
        var createtablefromDb = _db.ReimbursementDetails.Where(s => s.EmployeeID == (HttpContext.Session.GetString("Session")) && s.Status=="Pending");
        if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
            IEnumerable<Employees> employeedetailslist = (IEnumerable<Employees>) createtablefromDb;
            
        return View(employeedetailslist);
        }
        
        return RedirectToAction("LoginPage","Login");
    }
    public IActionResult ApprovedForm()
    {
        var createtablefromDb = _db.ReimbursementDetails.Where(s => s.EmployeeID == (HttpContext.Session.GetString("Session")) && s.Status=="Approved");
        if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
            IEnumerable<Employees> employeedetailslist = (IEnumerable<Employees>) createtablefromDb;
            
        return View(employeedetailslist);
        }
        
        return RedirectToAction("LoginPage","Login");
    }
    public IActionResult RejectedForm()
    {
        var createtablefromDb = _db.ReimbursementDetails.Where(s => s.EmployeeID == (HttpContext.Session.GetString("Session")) && s.Status=="Rejected");
        if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
            IEnumerable<Employees> employeedetailslist = (IEnumerable<Employees>) createtablefromDb;
            
        return View(employeedetailslist);
        }
        
        return RedirectToAction("LoginPage","Login");
    }
}