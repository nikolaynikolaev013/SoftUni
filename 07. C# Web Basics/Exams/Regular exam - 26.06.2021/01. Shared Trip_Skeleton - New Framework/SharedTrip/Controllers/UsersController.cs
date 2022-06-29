using System;
using System.Linq;
using System.Threading.Tasks;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.UsersModels;
using SharedTrip.Services;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(ApplicationDbContext db,
                IValidator validator,
                IPasswordHasher passwordHasher)
        {
            this.db = db;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Trips/All");
            }

            var hashedPassword = this.passwordHasher.HashPassword(password);

            var userId = this.db
                .Users
                .Where(x => x.Username == username && x.Password == hashedPassword)
                .Select(x => x.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                //return Error("Username and password combination is not valid.");
                return this.View();
            }

            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormInputModel input)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Trips/All");
            }

            var errors = this.validator.ValidateUser(input);

            if (this.db.Users.Any(x => x.Username == input.Username))
            {
                errors.Add($"There is already a user with that email. ({input.Username})");
            }

            if (this.db.Users.Any(x => x.Email == input.Email))
            {
                errors.Add($"There is already a user with that email. ({input.Email})");
            }

            if (errors.Any())
            {
                //It was this way at first, but moderators suggested to make it as it is in the task.
                //return this.Error(errors);
                return this.View();
            }

            var user = new User
            {
                Username = input.Username,
                Password = this.passwordHasher.HashPassword(input.Password),
                Email = input.Email,
            };

            db.Users.Add(user);

            db.SaveChanges();

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            this.SignOut();

            return Redirect("/");
        }
    }
}