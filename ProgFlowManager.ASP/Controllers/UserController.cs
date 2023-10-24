using Microsoft.AspNetCore.Mvc;
using ProgFlowManager.ASP.Models.ViewModels;
using ProgFlowManager.ASP.Tools;
using ProgFlowManager.Requester.API;

namespace ProgFlowManager.ASP.Controllers
{
    public class UserController : Controller
    {
        private readonly GenericAPIRequester _genericAPIRequester;
        private readonly SessionManager _sessionManager;

        public UserController(GenericAPIRequester genericAPIRequester, SessionManager sessionManager)
        {
            _genericAPIRequester = genericAPIRequester;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid) return View(register);

            if (_genericAPIRequester.Post<RegisterViewModel, bool>(register, "User/register")) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View(login);

            try
            {
                _sessionManager.Token = _genericAPIRequester.Post<LoginViewModel, string>(login, "User/login");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
