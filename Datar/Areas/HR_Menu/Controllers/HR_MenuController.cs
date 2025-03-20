using Microsoft.AspNetCore.Mvc;

namespace Datar.Areas.HR_Menu.Controllers
{
    [Area("HR_Menu")]
    [Route("HR_Menu/[Controller]/[action]")]
    public class HR_MenuController : Controller
    {
        public IActionResult FHR01()
        {
            return View();
        }

        public IActionResult DHR02()
        {
            return View();
        }

        public IActionResult PCMR03()
        {
            return View();
        }
        public IActionResult DHR01()
        {
            return View();
        }
    }
}
