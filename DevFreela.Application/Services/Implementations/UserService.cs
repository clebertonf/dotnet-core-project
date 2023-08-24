using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.infrastructure.Persistence;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel UserInputModel)
        {
            var user = new User(UserInputModel.FullName, UserInputModel.Email, UserInputModel.BirthDate);
            _dbContext.Users.Add(user);

            return user.Id;
        }

        public UserViewModel GetUser(int id)
        {
           var user = _dbContext.Users.FirstOrDefault(u => u.Id.Equals(id));
           if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email) ;
        }
    }
}
