using FluentValidation;

namespace StudentsDashboard.Application.WorkEvents.Commands.DeleteWorkEvent;

public class DeleteWorkEventValidator : AbstractValidator<DeleteWorkEventCommand>
{
    public DeleteWorkEventValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().WithMessage("You have to take a valid id of event!");
    }
}