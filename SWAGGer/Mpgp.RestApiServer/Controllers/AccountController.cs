// Copyright (c) MPGP. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mpgp.Abstract;
using Mpgp.Domain.Accounts.Commands;
using Mpgp.Domain.Accounts.Dtos;
using Mpgp.Domain.Accounts.Entities;
using Mpgp.Domain.Accounts.Queries;
using Mpgp.RestApiServer.Models.Examples;
using Mpgp.RestApiServer.Models.Examples.Account;
using Mpgp.RestApiServer.Models.Examples.Exception;
using Mpgp.RestApiServer.Utils;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mpgp.RestApiServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [SwaggerResponseExample(400, typeof(ValidationResponseExample))]
    [SwaggerResponseExample(404, typeof(NotFoundResponseExample))]
    [SwaggerResponseExample(409, typeof(ConflictResponseExample))]
    public class AccountController : Controller
    {
        private readonly ICommandFactory commandFactory;
        private readonly ILogger<AccountController> logger;
        private readonly IQueryFactory queryFactory;

        public AccountController(ICommandFactory commandFactory, ILogger<AccountController> logger, IQueryFactory queryFactory)
        {
            this.commandFactory = commandFactory;
            this.logger = logger;
            this.queryFactory = queryFactory;
        }

        /// <summary>
        /// Authorize a exists account.
        /// </summary>
        /// <param name="account"></param>
        [HttpPost]
        [SwaggerRequestExample(typeof(AuthorizeAccountCommand), typeof(AuthorizeRequestExample))]
        [SwaggerResponse(200, typeof(AuthDataDto), "Returns the authtoken of registered account.")]
        [SwaggerResponseExample(200, typeof(AuthDataResponseExample))]
        [SwaggerResponse(400, typeof(ErrorResponse), "If the model is invalid.")]
        [SwaggerResponse(404, typeof(ErrorResponse), "If the account was not found.")]
        public async Task<IActionResult> Authorize([FromBody]AuthorizeAccountCommand account, CancellationToken token = default(CancellationToken))
        {
            ModelState.ThrowValidationExceptionIfInvalid<Account.Errors>();

            await commandFactory.Execute(account);
            return Ok(new AuthDataDto(account.AuthToken));
        }

        /// <summary>
        /// Get account info.
        /// </summary>
        /// <param name="accountId"></param>
        [HttpGet("{accountId}")]
        [SwaggerResponse(200, typeof(AccountDto), "Returns the account info.")]
        [SwaggerResponseExample(200, typeof(InfoResponseExample))]
        [SwaggerResponse(404, typeof(ErrorResponse), "If the account was not found.")]
        public async Task<IActionResult> GetInfo(int accountId, CancellationToken token = default(CancellationToken))
        {
            var response = await queryFactory.ResolveQuery<AccountByIdQuery>().Execute(accountId);
            return Ok(AutoMapper.Mapper.Map<Account, AccountDto>(response));
        }

        /// <summary>
        /// Register a new account.
        /// </summary>
        /// <param name="account"></param>
        [HttpPut]
        [SwaggerRequestExample(typeof(RegisterAccountCommand), typeof(RegisterRequestExample))]
        [SwaggerResponse(201, typeof(AuthDataDto), "Returns the authtoken of newly registered account.")]
        [SwaggerResponseExample(201, typeof(AuthDataResponseExample))]
        [SwaggerResponse(400, typeof(ErrorResponse), "If the model is invalid.")]
        [SwaggerResponse(409, typeof(ErrorResponse), "If the login is already exists.")]
        public async Task<IActionResult> Register([FromBody]RegisterAccountCommand account, CancellationToken token = default(CancellationToken))
        {
            ModelState.ThrowValidationExceptionIfInvalid<Account.Errors>();

            await commandFactory.Execute(account);
            return StatusCode(201, new AuthDataDto(account.AuthToken));
        }

        /// <summary>
        /// Validate a token of exists account.
        /// </summary>
        /// <param name="authData"></param>
        [HttpPatch]
        [SwaggerRequestExample(typeof(ValidateTokenCommand), typeof(ValidateRequestExample))]
        [SwaggerResponse(200, null, "If the token is valid.")]
        [SwaggerResponse(404, typeof(ErrorResponse), "If the token was not found.")]
        public async Task<IActionResult> ValidateToken([FromBody]ValidateTokenCommand authData, CancellationToken token = default(CancellationToken))
        {
            ModelState.ThrowValidationExceptionIfInvalid<Account.Errors>();

            await commandFactory.Execute(authData);
            return Ok();
        }
    }
}