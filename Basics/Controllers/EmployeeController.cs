using Microsoft.AspNetCore.Mvc;
using Basics.Models;

namespace Basics.Controllers
{
    public class EmployeeController:Controller
    {
        //  public string Index()
        // {
        //     return "Hello Word";
        // }

         public IActionResult Index1()
        {
            string message=$"Hello Word . {DateTime.Now.ToString()}";
            return View("Index1",message);  
        }
        public ViewResult Index2()
        {
            var names=new String[]
            {
                "Büşra",
                "Meyra",
                "Gaye"
            };
            return View(names);
        }

        public IActionResult Index3()
        {   
            var list=new List<Employee>()
            {
               new Employee(){Id=1,FirstName="Büşra",LastName="Uludağ",Age=21},
               new Employee(){Id=2,FirstName="Meyra",LastName="Yöndemli",Age=22},
               new Employee(){Id=3,FirstName="Gaye",LastName="Kervan",Age=23}
            };
            return View("Index3",list);
        }
    }
}