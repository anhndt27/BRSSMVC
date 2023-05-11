using WebAppMVC.Data.Entities;

namespace WebAppMVC.Service.Interface
{
    public interface IUserService
    {
        Task<UserProfile> Details(int? id);
        Task<IEnumerable<UserProfile>> GetAll();
        Task Edit(UserProfile userProfile);
        Task Delete(int? id);
        Task Create(UserProfile entity);
    }
}
