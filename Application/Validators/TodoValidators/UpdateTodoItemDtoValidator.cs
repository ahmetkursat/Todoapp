using Application.DTOs;
using FluentValidation;

namespace TodoApi.Application.Validators.TodoValidators
{
    public class UpdateTodoItemDtoValidator : AbstractValidator<UpdateTodoItemDto>
    {
        public UpdateTodoItemDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title cannot be empty when provided")
                .MaximumLength(200)
                .WithMessage("Title cannot exceed 200 characters")
                .Must(BeAValidTitle)
                .WithMessage("Title cannot contain only whitespace")
                .When(x => x.Title != null);

            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .WithMessage("Description cannot exceed 1000 characters")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x)
                .Must(HaveAtLeastOneProperty)
                .WithMessage("At least one property must be provided for update");
        }

        private static bool BeAValidTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title);
        }

        private static bool HaveAtLeastOneProperty(UpdateTodoItemDto dto)
        {
            return dto.Title != null ||
                   dto.Description != null ||
                   dto.IsCompleted.HasValue;
        }
    }
}