using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanni.Store.Customers;
using fanni.Store.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace fanni.Store.Orders
{
    public class OrderAppService :
         CrudAppService<
             Order, //The Book entity
             OrderDto, //Used to show books
             int, //Primary key of the book entity
             PagedAndSortedResultRequestDto, //Used for paging/sorting
             CreateUpdateOrderDto>, //Used to create/update a book
         IOrderAppService //implement the IBookAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        public async Task<ListResultDto<CustomerLookupDto>> GetCustomerLookupAsync()
        {
            var customers = await _customerRepository.GetListAsync();

            return new ListResultDto<CustomerLookupDto>(
                ObjectMapper.Map<List<Customer>, List<CustomerLookupDto>>(customers)
            );
        }

        public async Task<ListResultDto<ProductLookupDto>> GetProductLookupAsync()
        {
            var products = await _productRepository.GetListAsync();

            return new ListResultDto<ProductLookupDto>(
                ObjectMapper.Map<List<Product>, List<ProductLookupDto>>(products)
            );
        }

        public OrderAppService(IRepository<Order, int> repository,
            ICustomerRepository customerRepository
            ,IProductRepository productRepository) : base(repository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public override async Task<OrderDto> GetAsync(int id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from order in queryable
                join customer in _customerRepository on order.CustomerId equals customer.Id 
                join product in _productRepository on order.ProductId equals product.Id
                where order.Id == id
                select new { order, customer,product };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            var orderDto = ObjectMapper.Map<Order, OrderDto>(queryResult.order);
            orderDto.CustomerName = queryResult.customer.Name;
            orderDto.ProductName = queryResult.product.Name;
            return orderDto;
        }

        public override async Task<PagedResultDto<OrderDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from order in queryable
                join customer in _customerRepository on order.CustomerId equals customer.Id
                join product in _productRepository on order.ProductId equals product.Id
                select new { order, customer,product };

            //Paging
            // query = query
            //     .OrderBy(NormalizeSorting(input.Sorting))
            //     .Skip(input.SkipCount)
            //     .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var orderDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Order, OrderDto>(x.order);
                bookDto.CustomerName = x.customer.Name;
                return bookDto;
            }
                ).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<OrderDto>(
                totalCount,
                orderDtos
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"order.{nameof(Order.Description)}";
            }

            if (sorting.Contains("customerName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "customerName",
                    "customer.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            if (sorting.Contains("productName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "productName",
                    "product.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"order.{sorting}";
        }

    }
}