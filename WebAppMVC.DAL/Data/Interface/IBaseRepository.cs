using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAppMVC.Data.Entity;

namespace WebAppMVC.Data.Interface
{
    public interface IBaseRepository<T> where T : BaseModels
    {
        Task<T> GetById(int? id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Delete(int id);
        Task Create(T entity);
       
    }
}
