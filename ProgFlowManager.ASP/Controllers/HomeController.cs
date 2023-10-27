using Microsoft.AspNetCore.Mvc;
using ProgFlowManager.ASP.Models;
using ProgFlowManager.ASP.Tools;
using ProgFlowManager.Requester.API;
using System.Diagnostics;

namespace ProgFlowManager.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly GenericAPIRequester _genericAPIRequester;
        private readonly SessionManager _sessionManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(GenericAPIRequester genericAPIRequester, SessionManager sessionManager, ILogger<HomeController> logger)
        {
            _genericAPIRequester = genericAPIRequester;
            _sessionManager = sessionManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}