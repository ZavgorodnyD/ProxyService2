using ProxyService2.Models;

namespace ProxyService2.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
    }
}
