using Microsoft.EntityFrameworkCore;
using Mo7tawa.DAL.Data;
using Mo7tawa.DAL.Interfaces;

namespace Mo7tawa.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entityUpdated)
        {
            _dbSet.Update(entityUpdated);
            await _context.SaveChangesAsync();
            return entityUpdated;
        }

        public async Task<TEntity?> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
