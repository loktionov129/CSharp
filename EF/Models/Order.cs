// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="EfTest">
//   EfTest
// </copyright>
// <summary>
//   Defines the Order type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EfTest.Models
{
    /// <summary>
    /// The customer.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public Customer Customer { get; set; }
    }
}
