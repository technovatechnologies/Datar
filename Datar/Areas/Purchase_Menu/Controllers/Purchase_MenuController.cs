using Microsoft.AspNetCore.Mvc;

namespace Datar.Areas.Purchase_Menu.Controllers
{
    [Area("Purchase_Menu")]
    [Route("Purchase_Menu/[Controller]/[action]")]
    public class Purchase_MenuController : Controller
    {
        public IActionResult PCPR01()
        {
            return View();
        }
        public IActionResult DPR01()
        {
            return View();
        }
        public IActionResult FPR01()
        {
            return View();
        }
        public IActionResult FPR02()
        {
            return View();
        }
        public IActionResult FPR03()
        {
            return View();
        }
    }
}
