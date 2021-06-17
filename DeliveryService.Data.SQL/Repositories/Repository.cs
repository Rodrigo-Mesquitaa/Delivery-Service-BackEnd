using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Data.SQL.Repositories
{
    public class Repository<TEntity> : DeliveryService.Application.Domain.Interfaces.IRepository<TEntity> where TEntity : class
    {
        protected DbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Db.Find<TEntity>(id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await Db.FindAsync<TEntity>(id);
        }

        public IQueryable<TEntity> Query()
        {
            return Db.Set<TEntity>().AsQueryable();
        }

        public async Task InsertAsync(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            await Db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entity = Db.Set<TEntity>().Find(id);

            Db.Entry(entity).State = EntityState.Deleted;
            await Db.SaveChangesAsync();
        }

        public void Add(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
        }

        public int SaveChanges() =>
            Db.SaveChanges();

        public Task SaveAsync() =>
            Db.SaveChangesAsync();


        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
