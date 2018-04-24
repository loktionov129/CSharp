using System;
using AutoMapper;

namespace NetRore.Csharp.Cmd
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            var domainUser = new Domain.User()
            {
                Id = 1,
                FirstName = "Axel",
                LastName = "Frog"
            };

            var dtoUser = Mapper.Map<Dto.User>(domainUser);

            Console.WriteLine("FName: " + dtoUser.FirstName);
            Console.WriteLine("LName: " + dtoUser.LastName);
            Console.WriteLine("Age: " + dtoUser.Age);
        }
    }
}