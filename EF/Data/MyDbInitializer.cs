// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyDbInitializer.cs" company="EfTest">
//   EfTest
// </copyright>
// <summary>
//   Defines the MyDbInitializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EfTest.Data
{
    /// <inheritdoc />
    public partial class MyDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<MyDbContext>
    {
        /// <summary>
        /// Gets or sets the db.
        /// </summary>
        protected MyDbContext Db { get; set; }

        /// <inheritdoc />
        protected override void Seed(MyDbContext db)
        {
            Db = db;

            SeedCustomers();
            SeedOrders();

            base.Seed(Db);
        }
    }
}
