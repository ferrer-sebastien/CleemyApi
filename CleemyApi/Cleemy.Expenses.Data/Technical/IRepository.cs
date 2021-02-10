using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cleemy.Expenses.Data.Technical
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        Task<List<T>> GetAll();

        Task<List<T>> GetAllOrderedBy(string expression);
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<List<T>> Find(Expression<Func<T, bool>> expression);
    }
}
