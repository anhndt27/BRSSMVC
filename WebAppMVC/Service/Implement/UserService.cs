using WebAppMVC.Data.Entities;
using WebAppMVC.Data.Interface;
using WebAppMVC.Service.Interface;

namespace WebAppMVC.Service.Implement
{
    public class UserService : IUserService
    {
        protected readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task Create(UserProfile entity)
        {
             await _userRepo.Create(entity);
        }

        public async Task Delete(int? id)
        {
            await _userRepo.Delete(id);
        }

        public async Task<UserProfile> Details(int? id)
        {
            return await _userRepo.Details(id);
        }

        public async Task Edit(UserProfile userProfile)
        {
            await _userRepo.Edit(userProfile);
        }

        public Task<IEnumerable<UserProfile>> GetAll()
        {
            return _userRepo.GetAll();
        }
    }
}
