using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using SharedTrip.Data;
using SharedTrip.Models.TripsModels;
using SharedTrip.Models.UsersModels;

namespace SharedTrip.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {

        public ICollection<string> ValidateUser(RegisterFormInputModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"The username ({model.Username}) must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (model.Email == null || !Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"The email entered ({model.Email}) is not a valid e-mail address.");
            }

            if (model.Password == null || model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The password must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != null && model.Password.Any(x => x == ' '))
            {
                errors.Add($"The password cannot contain whitespaces.");
            }
            
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("The password and its confirmation does not match.");
            }

            return errors;
        }

        public ICollection<string> ValidateTrip(AddTripFormInputModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.StartPoint))
            {
                errors.Add("A start point is required.");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                errors.Add("An end point is required.");
            }

            if (model.Seats < MinNumOfSeats || model.Seats > MaxNumOfSeats)
            {
                errors.Add($"The number of seats must be between {MinNumOfSeats} and {MaxNumOfSeats}.");
            }

            if (string.IsNullOrEmpty(model.Description) || model.Description.Length > MaxDescriptionLength)
            {
                errors.Add($"Description must have max length of {MaxDescriptionLength}.");
            }

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                errors.Add("Invalid departure time format. Please use <dd.MM.yyyy HH:ss> format.");
            }

            return errors;
        }
    }
}