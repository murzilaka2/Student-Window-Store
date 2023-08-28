using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;
using WebApplication1.Data.Helpers;

namespace WebApplication1.Controlles
{
    public class AuthController : Controller
    {
        private readonly IAllUser _allUser;
        private readonly IInvitation _invitation;

        public AuthController(IAllUser allUser, IInvitation invitation)
        {
            _allUser = allUser;
            _invitation = invitation;
        }

        public IActionResult Login()
        {
            var user = HttpContext.User.Identity;
            if (user != null && user.IsAuthenticated)
            {
                return Redirect("/account");
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var selectedUser = _allUser.GetUsers.FirstOrDefault(e => e.Email.ToLower().Equals(user.Email.ToLower()));
                if (selectedUser != null)
                {
                    string hashedPassword = SecurityHelper.HashPassword(user.Password, selectedUser.Salt, 10101, 70);
                    if (hashedPassword.Equals(selectedUser.HashedPassword))
                    {
                        var claims = new List<Claim> { new Claim("Email", selectedUser.Email), new Claim("Id", selectedUser.Id.ToString()),
                        new Claim("Role", selectedUser.Role)};
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return Redirect("/account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не верный пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Не верный E-Mail адрес");
                }
            }
            return View(user);
        }
        public ActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/Auth/Login");
        }
        public ActionResult Register(string code)
        {
            if (String.IsNullOrWhiteSpace(code))
            {
                return Redirect("/");
            }
            var currentCode = _invitation.Invitations.FirstOrDefault(e => e.Code.Equals(code));
            if (currentCode == null || currentCode.IsUsed)
            {
                return Redirect("/");
            }
            return View(new RegisterViewModel { Code = code });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                _invitation.MakeUsed(registerViewModel.Code);

                string salt = SecurityHelper.GenerateSalt(70);
                string hashedPassword = SecurityHelper.HashPassword(registerViewModel.Password, salt, 10101, 70);
                _allUser.AddUser(new Data.Models.User
                {
                    Email = registerViewModel.Email,
                    Name = registerViewModel.Name,
                    Role = "RegisteredUser",
                    HashedPassword = hashedPassword,
                    Salt = salt
                });
                return View(new RegisterViewModel { ConfirmMessage = "Регистрация успешно пройдена! Можете авторизоваться на сайте." });
            }
            return View(registerViewModel);
        }
        [AcceptVerbs("Get", "Post")]//указываем что метод одновременно обрабатывает 2 типа запросов
        [AllowAnonymous]//атрибут позволяет не авторизованым пользователям обращаться к методу
        public IActionResult IsEmailInUse(string email)
        {
            if (_allUser.GetUsers.Any(e => e.Email.Equals(email)))
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

    }
}
