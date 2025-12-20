using FluentValidation;

namespace TodoApi.Application.Validators.Extensions
{
    public static class ValidatorExtensions
    {
        public static async Task ValidateAndThrowCustomAsync<T>(
            this IValidator<T> validator,
            T instance)
        {
            var result = await validator.ValidateAsync(instance);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage);
                throw new ValidationException((IEnumerable<FluentValidation.Results.ValidationFailure>)errors);
            }
        }
    }
}