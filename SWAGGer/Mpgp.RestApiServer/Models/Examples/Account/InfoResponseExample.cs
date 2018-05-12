// Copyright (c) MPGP. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace Mpgp.RestApiServer.Models.Examples.Account
{
    internal class InfoResponseExample : Swashbuckle.AspNetCore.Examples.IExamplesProvider
    {
        public object GetExamples()
        {
            return new Domain.Accounts.Dtos.AccountDto
            {
                Avatar = "29.jpg",
                LastOnline = new System.DateTime(2018, 4, 4),
                Nickname = "AlexAnder",
                RegisterDate = new System.DateTime(2018, 1, 1)
            };
        }
    }
}
