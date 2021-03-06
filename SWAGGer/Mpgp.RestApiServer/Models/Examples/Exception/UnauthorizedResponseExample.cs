﻿// Copyright (c) MPGP. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace Mpgp.RestApiServer.Models.Examples.Exception
{
    internal class UnauthorizedResponseExample : Swashbuckle.AspNetCore.Examples.IExamplesProvider
    {
        public object GetExamples()
        {
            return new ErrorResponse { ErrorCode = 401, Message = "Unauthorized" };
        }
    }
}
