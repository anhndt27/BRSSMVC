using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data.Context;
using WebAppMVC.Data.Entity;
using WebAppMVC.Data.Interface;

namespace WebAppMVC.Data.Implement
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModels
    {

        protected AppDbContext dbContext;
        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var basemodels = await dbContext.FindAsync<T>(id);

            if (basemodels != null)
            {
                 dbContext.Remove(basemodels);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
