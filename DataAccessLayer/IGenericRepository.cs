using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(int id);
        void InsertAsync(TEntity entity);
        void DeleteAsync(int id);
        void UpdateAsync(TEntity entityToUpdate);
    }
}
