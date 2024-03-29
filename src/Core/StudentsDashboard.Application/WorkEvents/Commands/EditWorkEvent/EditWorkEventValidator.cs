using System.Data;
using FluentValidation;

namespace StudentsDashboard.Application.WorkEvents.Commands.EditWorkEvent;

public class EditWorkEventValidator : AbstractValidator<EditWorkEventCommand>
{
    public EditWorkEventValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().WithMessage("You must give ID");
    }
}