using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace fanni.Store.Orders
{
    public interface IOrderAppService : ICrudAppService< //Defines CRUD methods
            OrderDto, //Used to show books
            int, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOrderDto> //Used to create/update a book
    {
        // ADD the NEW METHOD
        // Task<ListResultDto<ProductLookupDto>> GetProductLookupAsync();
        // Task<ListResultDto<CustomerLookupDto>> GetCustomerLookupAsync();
    }
}