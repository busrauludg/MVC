using Microsoft.AspNetCore.Mvc;
using WebSitesi.Models;
namespace WebSitesi.Controllers
{
    public class KayitController:Controller
    {
        public IActionResult Index()
        {
           var model=Repository.Applications;
          return View(model);
        }

        public IActionResult Apply()
        {
           return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm]Candidate model)
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