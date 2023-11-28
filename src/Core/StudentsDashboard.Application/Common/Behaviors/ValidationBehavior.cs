using ErrorOr;
using FluentValidation;
using MediatR;

namespace StudentsDashboard.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public readonly IValidator<TRequest> _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validation = await _validator.ValidateAsync(request, cancellationToken);

        if (validation.IsValid)
        {
            return await next();
        }

        var errors = validation.Errors
            .ConvertAll(validationFailure => Error.Validation(
                code: validationFailure.PropertyName,
                description: validationFailure.ErrorMessage));

        return (dynamic)errors;
        
        throw new NotImplementedException();
    }
}