using Network.Domain.Entities;
using System.Linq;

namespace Network.Domain.Repositories
{
    interface IUserRepository
    {
        IQueryable<User> GetUsers();
    }
}
