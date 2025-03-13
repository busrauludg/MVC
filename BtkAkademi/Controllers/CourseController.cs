using BtkAkademi.Models;
using Microsoft.AspNetCore.Mvc;
namespace BtkAkademi.Controllers
{
    public class CourseController:Controller
    {
       public IActionResult Index()
       {
          return View();
       }
       public IActionResult Apply()//sunucudan bilği talep eden action
       {
          return View();
       }
       [HttpPost]
       [ValidateAntiForgeryToken]
       public IActionResult Apply([FromForm]Candidate model)//overroding metot aşırı yüklenme
       {
          return View();
       }


    }
}