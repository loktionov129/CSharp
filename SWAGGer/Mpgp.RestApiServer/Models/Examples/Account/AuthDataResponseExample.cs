// Copyright (c) MPGP. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace Mpgp.RestApiServer.Models.Examples.Account
{
    internal class AuthDataResponseExample : Swashbuckle.AspNetCore.Examples.IExamplesProvider
    {
        public object GetExamples()
        {
            return new Domain.Accounts.Dtos.AuthDataDto("392c2a901720d24e26be260ec331632f");
        }
    }
}
