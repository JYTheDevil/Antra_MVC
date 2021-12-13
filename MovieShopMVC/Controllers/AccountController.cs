using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            // we need to send the data to service , which is gonna convert in to User entity and send it to User Repository
            // save the data in the User table
            //
            var user =await _accountService.RegisterUser(userRegisterRequestModel);

            if (user == 0)
            {
                // email already exists
                return View();
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            return View();
        }
    }
}