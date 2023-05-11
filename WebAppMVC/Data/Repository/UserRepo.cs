using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data.Context;
using WebAppMVC.Data.Entities;
using WebAppMVC.Data.Interface;

namespace WebAppMVC.Data.Repository
{
    public class UserRepo : IUserRepo
    {

        protected AppDbContext _context;
       
     
        public UserRepo(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await _context.UserProfile.ToListAsync();
        }


        public async Task Create(UserProfile entity)
        {

            _context.UserProfile.Add(entity);
            await _context.SaveChangesAsync();
        }



        public async Task Delete(int? id)
        {
            var userProfile = await _context.UserProfile.FindAsync(id);

            if (userProfile != null)
            {
                _context.UserProfile.Remove(userProfile);
            }

            await _context.SaveChangesAsync();

        }



        public async Task<UserProfile> Details(int? id)
        {
             return await _context.UserProfile.FindAsync(id);
         
        }

        public async Task Edit(UserProfile userProfile)
        {
           
            _context.UserProfile.Update(userProfile);
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
       

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
