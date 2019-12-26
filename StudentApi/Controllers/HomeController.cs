using Microsoft.AspNetCore.Mvc;

namespace Student.Api.Controllers
{
    
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        
        [Route("/student")]
        public IActionResult Student()
        {
            return View();
        }

    }
}
