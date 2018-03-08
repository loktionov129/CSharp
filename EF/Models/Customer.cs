// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="EfTest">
//   EfTest
// </copyright>
// <summary>
//   Defines the Customer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EfTest.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer() => Orders = new HashSet<Order>();

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}
