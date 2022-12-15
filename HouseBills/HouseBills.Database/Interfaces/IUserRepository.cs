using HouseBills.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBills.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<UserApp> GetAllUsers();

        UserApp UsersGetById(string id);
    }
}
