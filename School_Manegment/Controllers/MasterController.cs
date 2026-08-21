using Microsoft.AspNetCore.Mvc;

namespace School_Manegment.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
