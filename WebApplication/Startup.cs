using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(WebApplication.Startup))]

namespace WebApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            var cookieAuthenticationOptions = new CookieAuthenticationOptions();

            cookieAuthenticationOptions.AuthenticationType = CookieAuthenticationDefaults.AuthenticationType;
            cookieAuthenticationOptions.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            cookieAuthenticationOptions.LoginPath = new PathString("/account/signin");
            cookieAuthenticationOptions.LogoutPath = new PathString("/home");
            cookieAuthenticationOptions.Provider = new DemoCookieAuthenticationProvider()
            {
                OnValidateIdentity = context =>
                {
                    return Task.FromResult(0);
                }
            };

            app.UseCookieAuthentication(cookieAuthenticationOptions);
        }
    }
}
