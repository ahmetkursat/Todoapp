using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators.TodoValidators
{
    public class CreateTodoItemDtoValidator : AbstractValidator<CreateTodoItemDto>
    {
        public CreateTodoItemDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title required")
                .MaximumLength(200)
                .WithMessage("Title cannot exceed 200 characters")
                .Must(BeAValidTitle)
                .WithMessage("Title cannot contain only whitespace");

            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .WithMessage("Description cannot exceed 1000 characters")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
        }
        private static bool BeAValidTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title);
        }
    }
}
