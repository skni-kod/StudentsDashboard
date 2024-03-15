using FluentValidation;

namespace StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask
{
    public class AddWorkTaskCommandValidator : AbstractValidator<AddWorkTaskCommand>
    {
        public AddWorkTaskCommandValidator() {

            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Date)
                 .NotEmpty().WithMessage("Date is required");
        }
    }
}
