using Microsoft.AspNetCore.Mvc;

namespace Datar.Areas.Marketing_Menu.Controllers
{
    [Area("Marketing_Menu")]
    [Route("Marketing_Menu/[Controller]/[action]")]
    public class Marketing_MenuController : Controller
    {
        public IActionResult PCMK01()
        {
            return View();
        }
        public IActionResult PCMK02()
        {
            return View();
        }
        public IActionResult DMK01()
        {
            return View();
        }

        public IActionResult DMK02()
        {
            return View();
        }

        public IActionResult FMK01()
        {
            return View();
        }

        public IActionResult FMK02()
        {
            return View();
        }

        public IActionResult FMK03()
        {
            return View();
        }

        public IActionResult FMK04()
        {
            return View();
        }

        public IActionResult FMK05()
        {
            return View();
        }
    }
}
