using Microsoft.AspNetCore.Mvc;

namespace Datar.Areas.StoreST_Menu.Controllers
{
    [Area("StoreST_Menu")]
    [Route("StoreST_Menu/[Controller]/[action]")]
    public class StoreST_MenuController : Controller
    {
        public IActionResult PCST01()
        {
            return View();
        }
        public IActionResult DST01()
        {
            return View();
        }
        public IActionResult FST01()
        {
            return View();
        }
        public IActionResult FST02()
        {
            return View();
        }
        public IActionResult FST03()
        {
            return View();
        }
    }
}
