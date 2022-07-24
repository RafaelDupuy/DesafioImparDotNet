using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioImpar.Infra.Repositories
{
    public class Repository<T> where T : Entity
    {
        private readonly ImparContext _context;

        private readonly DbSet<T> _currentSet;
        public Repository(ImparContext context)
        {
            _context = context;
            _currentSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
             => await _currentSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _currentSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> InsertAsync(T entity)
        {
            await _currentSet.AddAsync(entity);
            await SaveAsync();
            return entity.Id;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _currentSet.Update(entity);
            await SaveAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _currentSet.Remove(entity);
            await SaveAsync();
        }

        private async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
