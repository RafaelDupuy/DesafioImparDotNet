using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioImpar.Infra.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<int> InsertAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task Delete(T entity);
    }
}
