using System;
namespace SharedTrip.Models.UsersModels
{
    public class RegisterFormInputModel
    {
        public string Username { get; init; }

        public string Email { get; init; }

        public string  Password { get; init; }

        public string ConfirmPassword { get; init; }
    }
}
