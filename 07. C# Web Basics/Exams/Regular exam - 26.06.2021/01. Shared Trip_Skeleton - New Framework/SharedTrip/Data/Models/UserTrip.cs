using System;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        public string UserId { get; init; }

        public virtual User User { get; init; }

        public string TripId { get; init; }

        public virtual Trip Trip { get; init; }
    }
}


//•	Has UserId – a string
//•	Has User – a User object
//•	Has TripId– a string
//•	Has Trip – a Trip object
