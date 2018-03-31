// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RedisConnectorHelper.cs" company="Redis">
//   Redis
// </copyright>
// <summary>
//   Defines the RedisConnectorHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleApp1
{
    using System;
    using StackExchange.Redis;

    /// <summary>
    /// The redis connector helper.
    /// </summary>
    public class RedisConnectorHelper
    {
        /// <summary>
        /// The lazy connection.
        /// </summary>
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        /// <summary>
        /// Initializes static members of the <see cref="RedisConnectorHelper"/> class.
        /// </summary>
        static RedisConnectorHelper()
        {
            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("localhost"));
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        public static ConnectionMultiplexer Connection => LazyConnection.Value;
    }
}
