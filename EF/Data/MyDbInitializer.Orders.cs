// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyDbInitializer.Orders.cs" company="EfTest">
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
        /// The seed orders.
        /// </summary>
        protected void SeedOrders()
        {
            var initialOrders = new System.Collections.Generic.List<Order>
            {
                new Order { Title = "qwerty", CustomerId = 1 },
                new Order { Title = "trwrvt", CustomerId = 2 },
                new Order { Title = "puuip", CustomerId = 1 },
            };
            Db.Orders.AddRange(initialOrders);
        }
    }
}
