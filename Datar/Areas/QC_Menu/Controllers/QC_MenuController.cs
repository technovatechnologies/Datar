using Microsoft.AspNetCore.Mvc;

namespace Datar.Areas.QC_Menu.Controllers
{
    [Area("QC_Menu")]
    [Route("QC_Menu/[Controller]/[action]")]
    public class QC_MenuController : Controller
    {
        public IActionResult PCQC01()
        {
            return View();
        }
        public IActionResult PCQC02()
        {
            return View();
            
        }
        public IActionResult DQC02()
        {
            return View();
        }
        public IActionResult DQC04()
        {
            return View();
        }
        public IActionResult DQC05()
        {
            return View();
        }
    }
}
