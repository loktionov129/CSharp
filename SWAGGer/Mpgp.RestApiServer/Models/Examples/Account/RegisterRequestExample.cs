// Copyright (c) MPGP. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace Mpgp.RestApiServer.Models.Examples.Account
{
    internal class RegisterRequestExample : Swashbuckle.AspNetCore.Examples.IExamplesProvider
    {
        public object GetExamples()
        {
            return new Domain.Accounts.Commands.RegisterAccountCommand
            {
                Login = "admin2018",
                Nickname = "AlexAnder",
                Password = "12345678asdf",
                PasswordRepeat = "12345678asdf"
            };
        }
    }
}
