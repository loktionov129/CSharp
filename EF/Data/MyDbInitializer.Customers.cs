// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyDbInitializer.Customers.cs" company="EfTest">
//   EfTest
// </copyright>
// <summary>
//   Defines the MyDbInitializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EfTest.Data
{
    using Models;

    /// <inheritdoc />
    public partial class MyDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<MyDbContext>
    {
        /// <summary>
        /// The seed customers.
        /// </summary>
        protected void SeedCustomers()
        {
            var initialCustomers = new System.Collections.Generic.List<Customer>
            {
                new Customer { Age = 18, Name = "Axel" },
                new Customer { Age = 15, Name = "Tom" },
                new Customer { Age = 19, Name = "Nancy" }
            };
            Db.Customers.AddRange(initialCustomers);
        }
    }
}
