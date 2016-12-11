using System.Linq;
using Microsoft.Azure;

namespace WebApplication.Business.Authentication
{
    public class AuthenticationConfig : IAuthenticationConfig
    {
        public string Username => CloudConfigurationManager.GetSetting("Authentication.Username");
        public string Password => CloudConfigurationManager.GetSetting("Authentication.Password");
        public string AuthorizationCode => CloudConfigurationManager.GetSetting("Authentication.AuthorizationCode");
    }
}