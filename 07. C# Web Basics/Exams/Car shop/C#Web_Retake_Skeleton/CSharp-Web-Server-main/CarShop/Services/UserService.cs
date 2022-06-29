using System;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.UserModels;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly CarShopDbContext context;
        private readonly IPasswordHasher passwordHasher;

        public UserService(CarShopDbContext context,
                IPasswordHasher passwordHasher)
        {
            this.context = context;
            this.passwordHasher = passwordHasher;
        }

        public User GetUserByEmail(string email)
        {
            return this.context.Users
                .Where(x => x.Email == email)
                .FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return this.context.Users
                .Where(x => x.Username == username)
                .FirstOrDefault();
        }

        public string CheckIfUserIsValid(string username, string pass)
        {
            return this.context
                        .Users
                            .Where(x => x.Username == username
                            && x.Password == passwordHasher.HashPassword(pass))
                            .Select(x => x.Id)
                            .FirstOrDefault();

        }

        public async Task<User> RegisterUser(RegisterInputModel model)
        {
            var user = new User
            {
                Email = model.Email,
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                IsMechanic = model.UserType == "Mechanic" ? true : false,
            };

            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();

            return user;
        }

        public bool CheckIfUserIsMechanic(string userId)
        {
            var user = this.context
                    .Users
                    .Where(x => x.Id == userId)
                    .FirstOrDefault();

            return user != null && user.IsMechanic;
        }
    }
}
