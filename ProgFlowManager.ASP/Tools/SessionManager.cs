using Newtonsoft.Json;
using ProgFlowManager.BLL.Models.Users;
using ProgFlowManager.Requester.API;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProgFlowManager.ASP.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;
        private readonly GenericAPIRequester _genericAPIRequester;

        public SessionManager(IHttpContextAccessor httpContext, GenericAPIRequester genericAPIRequester)
        {
            _session = httpContext.HttpContext.Session;
            _genericAPIRequester = genericAPIRequester;
            IsMenuOpen = false;
        }

        public User? ConnectedUser
        {
            get { return string.IsNullOrEmpty(Token) ? null : _genericAPIRequester.Get<User>($"User/{int.Parse(new JwtSecurityToken(Token).Claims.First(c => c.Type == ClaimTypes.Sid).Value)}"); }
        }
        public string Token
        {
            get { return _session.GetString("token"); }
            set { _session.SetString("token", value); }
        }
        public bool IsMenuOpen
        {
            get { return _session.GetBool("isMenuOpen"); }
            set { _session.SetBool("isMenuOpen", value); }
        }

        public bool Logout()
        {
            try { _session.Remove("token"); }
            catch (Exception) { return false; }

            return true;
        }
    }
}
