using HouseBills.Domain.Interfaces;
using HouseBills.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBills.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly HouseBillsWebMvcDbContext _mvcDbContext;

        public UserRepository(HouseBillsWebMvcDbContext mvcDbContext)
        {
            _mvcDbContext = mvcDbContext;
        }

        public List<UserApp> GetAllUsers()
        {
            List<UserApp> users = _mvcDbContext.Users.ToList();

            return users;
        }

        public UserApp UsersGetById(string id)
        {
            var user = _mvcDbContext.Users.FirstOrDefault(x => x.Id == id);

            return user;
        }
    }
}
