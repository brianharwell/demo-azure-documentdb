using System.Linq;
using System.Web.Mvc;
using WebApplication.Business.Authentication;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AccountController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInVm signInVm)
        {
            if (!ModelState.IsValid)
            {
                return View(signInVm);
            }

            if (!_authenticationManager.ValidateCredentials(signInVm.Username, signInVm.Password, signInVm.AuthenticationCode))
            {
                ModelState.AddModelError("credentials", "Invalid credentials");

                return View(signInVm);
            }

            _authenticationManager.SignIn(signInVm.Username);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignOut()
        {
            _authenticationManager.SignOut();

            return RedirectToAction("SignIn");
        }
    }
}