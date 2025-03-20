using Microsoft.AspNetCore.Mvc;

namespace Datar.Areas.Maintenance_Menu.Controllers
{
    [Area("Maintenance_Menu")]
    [Route("Maintenance_Menu/[Controller]/[action]")]
    public class Maintenance_MenuController : Controller
    {
        public IActionResult FMT02()
        {
            return View();
        }

        public IActionResult FMT01()
        {
            return View();
        }

        public IActionResult DMT01()
        {
            return View();
        }

        public IActionResult DMT02()
        {
            return View();
        }

        public IActionResult PCMT01()
        {
            return View();
        }
    }
}
