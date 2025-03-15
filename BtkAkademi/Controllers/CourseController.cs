using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;
namespace BtkAkademi.Controllers
{
    public class CourseController:Controller
    {
       public IActionResult Index()
       {
         var model=Repository.Applications;
          return View(model);
       }
       public IActionResult Apply()//sunucudan bilği talep eden action
       {
          return View();
       }
       [HttpPost]
       [ValidateAntiForgeryToken]
       public IActionResult Apply([FromForm]Candidate model)//overroding metot aşırı yüklenme
       { 
         if(Repository.Applications.Any(c=>c.Email.Equals(model.Email)))
         {
            ModelState.AddModelError("","They is already an application for you");
         }
         if(ModelState.IsValid)
         {
            Repository.Add(model);
          //return RedirectToAction("Index");
          //return Redirect("/");
          return View("Feedback",model);
         }
         return View();
       }


    }
}