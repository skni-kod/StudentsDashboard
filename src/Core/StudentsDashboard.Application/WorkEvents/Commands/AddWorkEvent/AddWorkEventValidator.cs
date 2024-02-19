using System.Runtime.InteropServices.JavaScript;
using FluentValidation;

namespace StudentsDashboard.Application.WorkEvents.Commands.AddWorkEvent;

public class AddWorkEventValidator : AbstractValidator<AddWorkEventCommand>
{
    public AddWorkEventValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required");

        RuleFor(x => x.FromDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("You can't add older event");

        RuleFor(x => x.FromTime)
            .Must((model, value) => model.FromDate == DateOnly.FromDateTime(DateTime.Now) 
                                    && value <= TimeOnly.FromDateTime(DateTime.Now.AddMinutes(1)))
            .WithMessage("You can't add older event");

        RuleFor(x => x.ToDate)
            .Must((model, value) => value > model.FromDate)
            .WithMessage("You can't add older data ");

        RuleFor(x => x.ToTime)
            .Must((model, value) => value <= model.FromTime && model.ToDate <= model.FromDate)
            .WithMessage("You can't add older data");

    }
}