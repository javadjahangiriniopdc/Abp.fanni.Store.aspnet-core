using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using fanni.Store.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace fanni.Store.EntityFrameworkCore.Product
{
    class EfCoreProductRepository : EfCoreRepository<StoreDbContext, Products.Product, int>,
        IProductRepository
    {
        public EfCoreProductRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Products.Product> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(product => product.Name == name);
        }

        public async Task<List<Products.Product>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    Product => Product.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
