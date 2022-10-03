using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Interface;
using test.Models.UserModel;
using test.ViewModels;

namespace test.Controllers
{

    public class AuthenticateController : Controller
    {
        private readonly IMyAuthService authenticate;


        public AuthenticateController(IMyAuthService authenticate)
        {
            this.authenticate = authenticate;
        }
        public IActionResult Register()
        {
            return View("~/Views/Authenticate/Register.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDto model)
        {
            var response = await authenticate.AddUser(model);
            if (response.IsSuccess)
            {
                return View("~/Views/Authenticate/LogIn.cshtml");
            }
            return View("~/Views/Authenticate/Register.cshtml", response);
        }
        public async Task<IActionResult> LogIn()
        {
            return View("~/Views/Authenticate/LogIn.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserDto model)
        {

            var token = await authenticate.GetUserToken(model);
            if (token == null)
            {
                return View("~/Views/Authenticate/LogIn.cshtml");
            }
            Response.Cookies.Append("ChatToken", token.Token, new CookieOptions() { HttpOnly = true, Secure = true });
            return Redirect("~/Chat/ChatPage");
        }

    }
}
