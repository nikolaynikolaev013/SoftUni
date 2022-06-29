using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CarShop.Data;
using CarShop.Models.UserModels;

namespace CarShop.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        public Validator()
        {
        }

        public List<string> ValidateLoginForm(LoginInputModel model)
        {
            List<string> errors = new();

            if (model.Username == null || model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"The username must be with length between {UserMinUsername} and {DefaultMaxLength}.");
            }

            if (model.Password == null || model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The password must be with length between {UserMinPassword} and {DefaultMaxLength}.");
            }

            return errors;
        }

        public List<string> ValidateRegisterForm(RegisterInputModel model)
        {
            List<string> errors = new();

            if (model.Username == null || model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"The username must be with length between {UserMinUsername} and {DefaultMaxLength}.");
            }

            if (model.Email == null || !Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"The email you entered ({model.Email}) is not a valid email address. Please enter a valid one. (yourEmail@example.com)");
            }

            if (model.Password == null || model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The password must be with length between {UserMinPassword} and {DefaultMaxLength}.");
            }

            if (model.Password != null && model.Password.Any(x=>x == ' '))
            {
                errors.Add($"The password can't contain whitespaces.");
            }
            else if(model.Password != null && model.ConfirmPassword != null && model.ConfirmPassword != model.Password)
            {
                errors.Add($"The password and confirm password doesn't match.");
            }

            if (model.UserType != UserTypeClient && model.UserType != UserTypeMechanic)
            {
                errors.Add($"The type of user can be {UserTypeMechanic} or {UserTypeClient}.");
            }
            return errors;
        }
    }
}
