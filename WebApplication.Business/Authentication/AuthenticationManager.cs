using System.Linq;
using System.Security.Claims;

namespace WebApplication.Business.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly Microsoft.Owin.Security.IAuthenticationManager _authenticationManager;

        public AuthenticationManager(Microsoft.Owin.Security.IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public bool ValidateCredentials(string username, string password, string authenticationCode)
        {
            throw new System.NotImplementedException();
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
            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, username));

            return claimsIdentity;
        }
    }
}