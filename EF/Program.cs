// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="EfTest">
//   EfTest
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EfTest
{
    using System;
    using System.Linq;

    using Data;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                Console.WriteLine("Список объектов:");
                var query = db.Customers.Join(
                    db.Orders,
                    customer => customer.Id,
                    order => order.CustomerId,
                    (customer, order) => new
                    {
                        CustomerId = customer.Id,
                        customer.Name,
                        OrderId = order.Id,
                        order.Title,
                    });

                foreach (var item in query)
                {
                    Console.WriteLine("{0}.{1} - {2}.{3}", item.CustomerId, item.Name, item.OrderId, item.Title);
                }
            }
        }
    }
}
