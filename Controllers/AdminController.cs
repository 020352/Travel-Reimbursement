using System;
using Webapplication.Models;
using System.Diagnostics;
using Webapplication.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;


namespace Webapplication.Controllers;

public class AdminController: Controller
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ApplicationDbContext db,ILogger<AdminController> logger)
    {
        _logger = logger;
        _db=db;
    }
    public IActionResult Reports(Employees employees)
    {
        if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
            
            IEnumerable<Employees> employeedetailslist = _db.ReimbursementDetails.Where(m => m.Status!="Approved");
            IEnumerable<Employees> employeedetailslist1 = employeedetailslist.Where(v => v.Status !="Rejected");
            return View(employeedetailslist1);
        }
        return RedirectToAction("LoginPage","Login");
    }
    
    public IActionResult Approve(Employees employees)
    {
        employees.Status = "Approved";
        _db.ReimbursementDetails.Update(employees);
        _db.SaveChanges();
        return RedirectToAction("Reports","Admin");
    }

    // public IActionResult Approve(SignupAccount signupaccount)
    // {
    //     string subject="Hello";
    //     string message="this is the email";
    //     string receiver="karunyasaravanan192@gmail.com";
    //     try{
    //     var senderEmail=new MailAddress("dhivyankumar253@gmail.com","Dhivyan K");
    //     var receiverEmail= new MailAddress(receiver,"Receiver");
    //     var password="Kd.com@253";
    //     var sub= subject;
    //     var body=message;
    //     var smtp=new SmtpClient{
    //         Host="smtp.gmail.com",
    //         Port=587,
    //         EnableSsl=true,
    //         DeliveryMethod = SmtpDeliveryMethod.Network,
    //         UseDefaultCredentials=false,
    //        // Credentials = new NetworkCredential(senderEmail.Address, password)
    //     };
    //     using(var mess= new MailMessage(senderEmail,receiverEmail)
    //     {
    //         Subject=subject,
    //         Body=body
    //     })  {
    //         smtp.Send(mess);
    //         Console.WriteLine("Mail sent");
    //     }
    //    return RedirectToAction("Reports","Admin");
    //     }
    //     catch(Exception){
    //         Console.WriteLine("Error");
    //     }
    //     return RedirectToAction("Reports","Admin");
    // }
     public IActionResult Reject(Employees employees)
    {
        employees.Status = "Rejected";
        _db.ReimbursementDetails.Update(employees);
        _db.SaveChanges();
        return RedirectToAction("Reports","Admin");
    }
    public IActionResult Home()
    {
        if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
        {
        return View();
        }
        return RedirectToAction("LoginPage","Login");
    }
    public IActionResult AdminProfile()
   {
    SignupAccount signupaccount =  Validation.myProfile(HttpContext.Session.GetString("Session"));
    
    if(!string.IsNullOrEmpty(ViewBag.Message=HttpContext.Session.GetString("Session")))
    {
        
    return View(signupaccount);
    }
    return RedirectToAction("LoginPage","Login");
   }
}