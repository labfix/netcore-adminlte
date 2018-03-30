using Microsoft.AspNetCore.Mvc;

namespace AdminLTE.WebUI.Controllers
{
   public class HomeController : Controller
   {
       public IActionResult Index()
       {
           return View();
       }
   }
}
