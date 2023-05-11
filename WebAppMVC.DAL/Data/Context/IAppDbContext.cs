using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Data.Entity;

namespace WebAppMVC.DAL.Data.Context
{
    public interface IAppDbContext 
    {
        DbSet<T> Set<T>(T entity) where T : BaseModels;
        int SaveChange();
    }
}
