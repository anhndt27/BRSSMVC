using WebAppMVC.Data.Entity;

namespace WebAppMVC.Data.Interface
{
    public interface IUserRepository : IBaseRepository<BaseModels>
    {
        Task<User> CreateAsync(User entity);
    }
}
