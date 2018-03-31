// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Redis">
//   Redis
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleApp1
{
    using System;

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
            var program = new Program();

            Console.WriteLine("Saving random data in cache");
            program.SaveBigData();

            Console.WriteLine("Reading data from cache");
            program.ReadData();

            Console.ReadLine();
        }

        /// <summary>
        /// The read data.
        /// </summary>
        public void ReadData()
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            const int DevicesCount = 100;
            for (var i = 0; i < DevicesCount; i++)
            {
                var value = cache.StringGet($"Device_Status:{i}");
                Console.WriteLine($"Valor={value}");
            }
        }

        /// <summary>
        /// The save big data.
        /// </summary>
        public void SaveBigData()
        {
            const int DevicesCount = 100;
            var rnd = new Random();
            var cache = RedisConnectorHelper.Connection.GetDatabase();

            for (var i = 0; i < DevicesCount; i++)
            {
                var value = rnd.Next(0, 10000);
                cache.StringSet($"Device_Status:{i}", value);
            }
        }
    }
}
