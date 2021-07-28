using System;
using System.Threading.Tasks;
using fanni.Store.Customers;
using fanni.Store.Orders;
using fanni.Store.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Order, Guid> _orderRepository;

        public BookStoreDataSeederContributor(
            IRepository<Customer, Guid> customerRepository,
            IRepository<Product, Guid> productRepository,
            IRepository<Order, Guid> orderRepository
            )
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _customerRepository.GetCountAsync() <= 0)
            {
                #region Customer
                var customer_javad_jahangiri = await _customerRepository.InsertAsync(
                    new Customer
                    {
                        Name = "javad",
                        Family = "jahangiri",
                        Birthday = new DateTime(1986, 6, 8),
                    },
                    autoSave: true
                );

                var customer_amin_jahangiri = await _customerRepository.InsertAsync(
                    new Customer
                    {
                        Name = "amin",
                        Family = "jahangiri",
                        Birthday = new DateTime(1990, 6, 8),
                    },
                    autoSave: true
                );



                #endregion

                #region Product
                var product_nokia = await _productRepository.InsertAsync(
                    new Product
                    {
                        Name = "nokia",
                        ProductType = ProductType.Mobile,
                        Pirce = 1000
                    },
                    autoSave: true
                );

                var product_thinkpad = await _productRepository.InsertAsync(
                    new Product
                    {
                        Name = "Thinkpad",
                        ProductType = ProductType.Computer,
                        Pirce = 2000
                    },
                    autoSave: true
                );
                #endregion

                #region Order

                await _orderRepository.InsertAsync(
                    new Order
                    {
                        CustomerId =customer_javad_jahangiri.Id, 
                        ProductId =product_thinkpad.Id,
                        Description = "Order javad jahangiri product thinkpad",
                        Pirce = 1000,
                        Count = 20,
                        PriceAll = 20000,
                    },
                    autoSave: true
                );

                await _orderRepository.InsertAsync(
                    new Order
                    {
                        CustomerId = customer_javad_jahangiri.Id,
                        ProductId = product_nokia.Id,
                        Description = "Order javad jahangiri product thinkpad",
                        Pirce = 1000,
                        Count = 20,
                        PriceAll = 20000,
                    },
                    autoSave: true
                );

                await _orderRepository.InsertAsync(
                    new Order
                    {
                        CustomerId = customer_amin_jahangiri.Id,
                        ProductId = product_thinkpad.Id,
                        Description = "Order amin jahangiri product thinkpad",
                        Pirce = 1000,
                        Count = 20,
                        PriceAll = 20000,
                    },
                    autoSave: true
                );

                await _orderRepository.InsertAsync(
                    new Order
                    {
                        CustomerId = customer_amin_jahangiri.Id,
                        ProductId = product_nokia.Id,
                        Description = "Order amin jahangiri product thinkpad",
                        Pirce = 1000,
                        Count = 20,
                        PriceAll = 20000,
                    },
                    autoSave: true
                );
                #endregion

            }
        }
    }
}