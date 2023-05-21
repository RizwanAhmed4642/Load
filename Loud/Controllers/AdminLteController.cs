using Microsoft.AspNetCore.Mvc;

namespace AdminLte3MVC.Controllers
{
    public class AdminLteController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
