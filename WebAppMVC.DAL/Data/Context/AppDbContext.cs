using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using WebAppMVC.DAL.Data.Context;
using WebAppMVC.Data.Entity;

namespace WebAppMVC.Data.Context
{
    public class AppDbContext : IdentityDbContext<User>, IAppDbContext
    {

        DbSet<BaseModels>? baseModels { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<T> Set<T>(T entity) where T : BaseModels
        {
            return base.Set<T>();
        }

        public int SaveChange()
        {
            throw new NotImplementedException();
        }
    }
}
