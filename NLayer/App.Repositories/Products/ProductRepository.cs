using App.Repositories.Entity;
using App.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Products;

public class ProductRepository(AppDbContext dbContext) : GenericRepository<Product>(dbContext), IProductRepository
{
    public Task<List<Product>> GetTopPriceProductAsync(int count) =>
        Context.Products.OrderByDescending(x => x.Price).Take(count).ToListAsync();
    //Not tek is se await gerek yok 
}