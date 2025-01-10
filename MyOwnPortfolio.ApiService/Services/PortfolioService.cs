using Microsoft.EntityFrameworkCore;
using MyOwnPortfolio.ApiService.Services.Interface;

namespace MyOwnPortfolio.ApiService.Services
{
    public class PortfolioService<T> : IPortfolioService<T> where T : class
    {
        private MyPortfolioDbContext _context = null;
        private DbSet<T> table = null;
        //public PortfolioService()
        //{
        //    this._context = new MyPortfolioDbContext();
        //    table = _context.Set<T>();
        //}

        public PortfolioService(MyPortfolioDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public async Task<IQueryable<T>> GetAll()
        {
            return table.AsQueryable();
        }
        public async Task<T?> GetById(long id)
        {
            return await table.FindAsync(id);
        }
        public async Task<T> Insert(T entity)
        {
            await table.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            table.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                T existing = await table.FindAsync(id);
                table.Remove(existing);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
