using FluentValidation;
using LodgerPms.Departments.Api.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Application.Decorators
{
    public class ValidatorDecorator<TRequest, TResponse>
       : IAsyncRequestHandler<TRequest, TResponse>
        where TRequest : IAsyncRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> _inner;
        private readonly IValidator<TRequest>[] _validators;


        public ValidatorDecorator(
            IAsyncRequestHandler<TRequest, TResponse> inner,
            IValidator<TRequest>[] validators)
        {
            _inner = inner;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest message)
        {
            var failures = _validators
                .Select(v => v.Validate(message))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                throw new DepartmentDomainException(
                    $"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));
            }

            var response = await _inner.Handle(message);

            return response;
        }
    }
}
