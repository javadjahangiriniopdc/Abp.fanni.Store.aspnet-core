using fanni.Store.Customers;
using fanni.Store.Orders;
using fanni.Store.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace fanni.Store.EntityFrameworkCore
{
    public static class StoreDbContextModelCreatingExtensions
    {
        public static void ConfigureStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Customers.Customer>(b =>
            {
                b.ToTable(StoreConsts.DbTablePrefix + "Customers",
                    StoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });

            builder.Entity<Products.Product>(b =>
            {
                b.ToTable(StoreConsts.DbTablePrefix + "Products",
                    StoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });

            builder.Entity<Order>(b =>
            {
                b.ToTable(StoreConsts.DbTablePrefix + "Orders",
                    StoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Description).IsRequired().HasMaxLength(128);

                b.HasOne<Customers.Customer>().WithMany().HasForeignKey(x => x.CustomerId).IsRequired();
                b.HasOne<Products.Product>().WithMany().HasForeignKey(x => x.ProductId).IsRequired();

            });

        }
    }
}