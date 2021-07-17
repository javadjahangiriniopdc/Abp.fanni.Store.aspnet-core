using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace fanni.Store.Customers
{
    public interface ICustomerRepository: IRepository<Customer, int>
    {
        Task<Customer> FindByNameAsync(string name);

        Task<List<Customer>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
