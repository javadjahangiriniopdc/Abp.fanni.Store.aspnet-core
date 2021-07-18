using AutoMapper;
using fanni.Store.Customers;
using fanni.Store.Orders;
using fanni.Store.Products;

namespace fanni.Store
{
    public class StoreApplicationAutoMapperProfile : Profile
    {
        public StoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateUpdateCustomerDto, Customer>();

            CreateMap<Product, ProductDto>();
            CreateMap<CreateUpdateProductDto, Product>();

            CreateMap<Order, OrderDto>();
            CreateMap<CreateUpdateOrderDto, Order>();

            CreateMap<Customer, CustomerLookupDto>();
            CreateMap<Product, ProductLookupDto>();

        }
    }
}
