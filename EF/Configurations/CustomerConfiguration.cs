// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerConfiguration.cs" company="EfTest">
//   EfTest
// </copyright>
// <summary>
//   Defines the CustomerConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EfTest.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Models;

    /// <inheritdoc />
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        /// <inheritdoc />
        public CustomerConfiguration()
        {
            HasMany(c => c.Orders).WithRequired(o => o.Customer);

            Property(c => c.Age).IsRequired();
            Property(c => c.Name).IsRequired().HasMaxLength(50);

            ToTable("Customers");
        }
    }
}
