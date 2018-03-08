// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderConfiguration.cs" company="EfTest">
//   EfTest
// </copyright>
// <summary>
//   Defines the OrderConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EfTest.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Models;

    /// <inheritdoc />
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        /// <inheritdoc />
        public OrderConfiguration()
        {
            HasRequired(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            Property(c => c.Title).IsRequired().HasMaxLength(30);

            ToTable("Orders");
        }
    }
}
