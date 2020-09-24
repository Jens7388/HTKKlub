using HTKKlub.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HTKKlub.DataAccess
{
    public interface IRepositoryBase<T>
    {
        HTKContext Context { get; set; }

        Task AddAsync(T t);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync();
        Task DeleteAsync(T t);
    }
}