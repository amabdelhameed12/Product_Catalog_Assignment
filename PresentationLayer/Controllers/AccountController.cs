using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Product_Catalog.BLL.Services;

namespace Product_Catalog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _user;

        public AccountController(IUserServices user) 
        {
            _user=user;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string password)
        {
            var Account =await _user.FoundBll(Email, password);
            if (Account)
            {
                var customermodel = await _user.FindBll(Email, password);
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim("Id", customermodel.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, customermodel.Name.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role,customermodel.Role.ToString()));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
        public async Task< IActionResult> SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
