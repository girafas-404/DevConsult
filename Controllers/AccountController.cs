using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using cp4_Projeto.Models;

namespace cp4_Projeto.Controllers
{
    public class AccountController : Controller
    {
        // Usuário admin fixo para demonstração
        private const string AdminUser = "admin";
        private const string AdminPass = "admin123";

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Dashboard", "Admin");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Validação simples de credenciais
            if (model.Usuario == AdminUser && model.Senha == AdminPass)
            {
                // Criação das Claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Usuario),
                    new Claim(ClaimTypes.Role, "TechLider"),
                    new Claim("FullName", "Tech Leader Admin"),
                    new Claim(ClaimTypes.Email, "admin@consultoria.com")
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2)
                };

                // Autenticar com Claims
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Dashboard", "Admin");
            }

            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
