namespace MyOwnPortfolio.ApiService.Services.Interface
{
    public interface IPortfolioService<T> where T : class
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(long id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(long id);

    }
}
