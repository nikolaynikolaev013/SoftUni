using System;
using System.Threading.Tasks;
using CarShop.Data.Models;
using CarShop.Models.UserModels;

namespace CarShop.Services
{
    public interface IUserService
    {
        public Task<User> RegisterUser(RegisterInputModel model);

        public User GetUserByUsername(string username);

        public User GetUserByEmail(string email);

        public string CheckIfUserIsValid(string username, string pass);

        public bool CheckIfUserIsMechanic(string userId);
    }
}
