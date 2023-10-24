﻿using Newtonsoft.Json;
using ProgFlowManager.ASP.Models.ModelsAPI.Users;
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
        }

        public User? ConnectedUser
        {
            get
            {
                return string.IsNullOrEmpty(Token) ? null : _genericAPIRequester.Get<User>($"User/{int.Parse(new JwtSecurityToken(Token).Claims.First(c => c.Type == ClaimTypes.Sid).Value)}");

                //return (string.IsNullOrEmpty(_session.GetString("connectedUser"))) ? null : JsonConvert.DeserializeObject<User>(_session.GetString("connectedUser"));
            }
            //set
            //{
            //    _session.SetString("connectedUser", JsonConvert.SerializeObject(value));
            //}
        }
        public string Token
        {
            get { return _session.GetString("token"); }
            set { _session.SetString("token", value); }
        }

        public bool Logout()
        {
            try { _session.Clear(); }
            catch (Exception) { return false; }

            return true;
        }
    }
}