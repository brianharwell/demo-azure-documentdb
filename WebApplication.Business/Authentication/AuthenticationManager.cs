using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.Owin.Security.Cookies;

namespace WebApplication.Business.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly Microsoft.Owin.Security.IAuthenticationManager _authenticationManager;
        private readonly IAuthenticationConfig _authenticationConfig;

        public AuthenticationManager(Microsoft.Owin.Security.IAuthenticationManager authenticationManager, IAuthenticationConfig authenticationConfig)
        {
            _authenticationManager = authenticationManager;
            _authenticationConfig = authenticationConfig;
        }

        public bool ValidateCredentials(string username, string password, string authenticationCode)
        {
            if (!string.Equals(username, _authenticationConfig.Username, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!string.Equals(password, _authenticationConfig.Password))
            {
                return false;
            }

            if (!string.Equals(authenticationCode, _authenticationConfig.AuthorizationCode))
            {
                return false;
            }

            return true;
        }

        public void SignIn(string username)
        {
            var claimsIdentity = CreateClaimsIdentity(username);

            _authenticationManager.SignIn(claimsIdentity);
        }

        public void SignOut()
        {
            _authenticationManager.SignOut();
        }

        private ClaimsIdentity CreateClaimsIdentity(string username)
        {
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType);

            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, username));

            return claimsIdentity;
        }
    }
}