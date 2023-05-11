using WebAppMVC.Data.Entities;

namespace WebAppMVC.Data.Interface
{
    public interface IUserRepo : IDisposable
    {
        Task<UserProfile> Details(int? id);
        Task<IEnumerable<UserProfile>> GetAll();
        Task Edit(UserProfile userProfile);
        Task Delete(int? id);
        Task Create(UserProfile entity);
    
        
    }
}
