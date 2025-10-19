using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Repositories;

public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T> where T : class
{
    protected AppDbContext Context = dbContext; 
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();

    public async ValueTask<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void UpdateAsync(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public IQueryable<T> Where(Expression<Func<T, bool>> expression) =>
        _dbSet.Where(expression).AsNoTracking();
}