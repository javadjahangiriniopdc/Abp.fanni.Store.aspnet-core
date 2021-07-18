using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using fanni.Store.Customers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace fanni.Store.EntityFrameworkCore.Customer
{
    class EfCoreCustomerRepository : EfCoreRepository<StoreDbContext, Customers.Customer, int>,
        ICustomerRepository
    {
        public EfCoreCustomerRepository(IDbContextProvider<StoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Customers.Customer> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(customer => customer.Name == name);
        }

        public async Task<List<Customers.Customer>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    customer => customer.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
