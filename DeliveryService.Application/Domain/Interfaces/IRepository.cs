using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Application.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable
    {

        T Get(int id);

        Task<T> GetAsync(int id);

        IQueryable<T> Query();

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        void Add(T entity);

        int SaveChanges();

        Task SaveAsync();


    }
}