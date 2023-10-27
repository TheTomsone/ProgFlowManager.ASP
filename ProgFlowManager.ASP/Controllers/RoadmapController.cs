using Microsoft.AspNetCore.Mvc;

namespace ProgFlowManager.ASP.Controllers
{
    public class RoadmapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
