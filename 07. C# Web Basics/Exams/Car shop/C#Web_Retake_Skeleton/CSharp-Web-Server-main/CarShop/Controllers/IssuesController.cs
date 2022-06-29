using System;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        public IssuesController()
        {
        }

        public HttpResponse CarIssues()
        {
            return this.View();
        }
    }
}
