using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;

namespace WebApplication
{
    public class DemoCookieAuthenticationProvider : CookieAuthenticationProvider
    {
        public override Task ValidateIdentity(CookieValidateIdentityContext context)
        {
            return base.ValidateIdentity(context);
        }
    }
}