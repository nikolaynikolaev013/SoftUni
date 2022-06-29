using System;
using System.Collections.Generic;
using CarShop.Models.UserModels;

namespace CarShop.Services
{
    public interface IValidator
    {
        public List<string> ValidateLoginForm(LoginInputModel model);
        public List<string> ValidateRegisterForm(RegisterInputModel model);
    }
}
