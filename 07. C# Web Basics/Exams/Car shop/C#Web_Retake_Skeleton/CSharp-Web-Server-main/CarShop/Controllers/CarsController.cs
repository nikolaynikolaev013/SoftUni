using System;
using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUserService userService;

        public CarsController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Add()
        {
            if (this.userService.CheckIfUserIsMechanic(this.User.Id))
            {
                return this.Error("Mechanics cannot add cars!");
            }
            return this.View();
        }
    }
}
