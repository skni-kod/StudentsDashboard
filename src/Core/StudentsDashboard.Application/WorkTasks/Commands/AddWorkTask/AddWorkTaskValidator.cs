using FluentValidation;

namespace StudentsDashboard.Application.WorkTasks.Commands.AddWorkTask
{
    public class AddWorkTaskValidator : AbstractValidator<AddWorkTaskCommand>
    {
        public AddWorkTaskValidator() {

            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Date)
                 .NotEmpty().WithMessage("Date is required");
        }
    }
}
