using System;
using CarShop.Models.UserModels;
using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserService userService;

        public UsersController(IValidator validator,
            IPasswordHasher passwordHasher,
            IUserService userService)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            var errors = this.validator.ValidateLoginForm(model);

            var checkedUserId = this.userService.CheckIfUserIsValid(model.Username, model.Password);

            if (checkedUserId == null)
            {
                errors.Add("The combination of username and passwords is not correct.");
            }

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            this.SignIn(checkedUserId);

            return Redirect("/Cars/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            var errors = this.validator.ValidateRegisterForm(model);

            if (this.userService.GetUserByEmail(model.Email) != null)
            {
                errors.Add($"There is already registered user with that email ({model.Email}).");
            }

            if (this.userService.GetUserByUsername(model.Username) != null)
            {
                errors.Add($"There is already registered user with that username ({model.Username}).");
            }

            if (errors.Count > 0)
            {
                return this.Error(errors);
            }

            this.userService.RegisterUser(model);

            return this.Redirect("/Users/Login");
        }
    }
}
