using System;
using System.Linq;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.TripsModels;
using SharedTrip.Services;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IValidator validator;

        public TripsController(ApplicationDbContext db,
                IValidator validator)
        {
            this.db = db;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var model = this.db
                    .Trips
                    .Select(x => new GetAllTripsViewModel()
                    {
                        Id = x.Id,
                        DepartureTime = x.DepartureTime,
                        AvailableSeats = x.Seats - x.UserTrips.Count,
                        EndPoint = x.EndPoint,
                        StartPoint = x.StartPoint
                    })
                    .ToList();

            return this.View(model);
        }

        public HttpResponse Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripFormInputModel input)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var errors = this.validator.ValidateTrip(input);

            if (errors.Any())
            {
                //It was this way at first, but moderators suggested to make it as it is in the task.
                //return this.Error(errors);
                return this.View();
            }

            var newTrip = new Trip()
            {
                DepartureTime = DateTime.Parse(input.DepartureTime),
                Description = input.Description,
                EndPoint = input.EndPoint,
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                StartPoint = input.StartPoint
            };

            this.db.Trips.Add(newTrip);

            this.db.SaveChanges();

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect($"/Users/Login");
            }

            var model = this.db
                    .Trips
                    .Where(x => x.Id == tripId)
                    .Select(x => new SingleTripDetailsViewModel
                    {
                        Id = x.Id,
                        DepartureTime = x.DepartureTime,
                        EndPoint = x.EndPoint,
                        Description = x.Description,
                        ImageUrl = x.ImagePath,
                        Seats = x.Seats - x.UserTrips.Count,
                        StartPoint = x.StartPoint
                    })
                    .FirstOrDefault();

            return this.View(model);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User.Id;

            var userTrip = this.db
                .UserTrips
                .Any(x => x.UserId == userId &&
                            x.TripId == tripId);

            if (userTrip)
            {
                return this.Redirect($"Details?tripId={tripId}");
            }

            var newUserTrip = new UserTrip()
            {
                TripId = tripId,
                UserId = userId
            };

            this.db.UserTrips.Add(newUserTrip);

            this.db.SaveChanges();

            return this.Redirect($"All");
        }
    }
}
