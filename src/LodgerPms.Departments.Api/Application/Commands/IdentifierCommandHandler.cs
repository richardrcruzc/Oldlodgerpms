﻿
using LodgerPms.Departments.Api.Infrastructure.Idempotency;
using MediatR;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Application.Commands
{
    /// <summary>
    /// Provides a base implementation for handling duplicate request and ensuring idempotent updates, in the cases where
    /// a requestid sent by client is used to detect duplicate requests.
    /// </summary>
    /// <typeparam name="T">Type of the command handler that performs the operation if request is not duplicated</typeparam>
    /// <typeparam name="R">Return value of the inner command handler</typeparam>
    public class IdentifierCommandHandler<T, R> : IAsyncRequestHandler<IdentifiedCommand<T, R>, R>
        where T : IAsyncRequest<R>
    {
        private readonly IMediator _mediator;
        private readonly IRequestManager _requestManager;

        public IdentifierCommandHandler(IMediator mediator, IRequestManager requestManager)
        {
            _mediator = mediator;
            _requestManager = requestManager;
        }

        /// <summary>
        /// Creates the result value to return if a previous request was found
        /// </summary>
        /// <returns></returns>
        protected virtual R CreateResultForDuplicateRequest()
        {
            return default(R);
        }

        /// <summary>
        /// This method handles the command. It just ensures that no other request exists with the same ID, and if this is the case
        /// just enqueues the original inner command.
        /// </summary>
        /// <param name="message">IdentifiedCommand which contains both original command & request ID</param>
        /// <returns>Return value of inner command or default value if request same ID was found</returns>
        public async Task<R> Handle(IdentifiedCommand<T, R> message)
        {
            var alreadyExists = await _requestManager.ExistAsync(message.Id);
            if (alreadyExists)
            {
                return CreateResultForDuplicateRequest();
            }
            else
            {
                await _requestManager.CreateRequestForCommandAsync<T>(message.Id);

                var result = await _mediator.SendAsync(message.Command);

                return result;
            }
        }
    }

}
