// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyDbContext.cs" company="EfTest">
//   EfTest
// </copyright>
// <summary>
//   Defines the MyDbContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EfTest.Data
{
    using System.Data.Entity;

    using Configurations;
    using Models;

    /// <inheritdoc />
    public class MyDbContext : DbContext
    {
        /// <inheritdoc />
        static MyDbContext()
        {
            Database.SetInitializer(new MyDbInitializer());
        }

        /// <inheritdoc />
        public MyDbContext()
            : base("DbConnection")
        {
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
        }
    }
}
