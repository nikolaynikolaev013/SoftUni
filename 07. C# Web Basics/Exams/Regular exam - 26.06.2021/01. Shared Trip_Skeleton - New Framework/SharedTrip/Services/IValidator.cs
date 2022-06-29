using System;
using System.Collections.Generic;
using SharedTrip.Models.TripsModels;
using SharedTrip.Models.UsersModels;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        public ICollection<string> ValidateUser(RegisterFormInputModel model);

        public ICollection<string> ValidateTrip(AddTripFormInputModel model);
    }
}
