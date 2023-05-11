using WebAppMVC.Data.Context;
using WebAppMVC.Data.Entity;
using WebAppMVC.Data.Interface;

namespace WebAppMVC.Data.Implement
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Task Create(BaseModels entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(BaseModels entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<BaseModels>> IBaseRepository<BaseModels>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<BaseModels> IBaseRepository<BaseModels>.GetById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
