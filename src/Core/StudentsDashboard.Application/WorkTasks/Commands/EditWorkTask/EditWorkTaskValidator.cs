using FluentValidation;

namespace StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask
{
    public class EditWorkTaskValidator : AbstractValidator<EditWorkTaskCommand>
    {
        public EditWorkTaskValidator() {

            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");

             RuleFor(x => x)
            .Custom((x, context) =>
            {
                if (x.Date == null && string.IsNullOrEmpty(x.Desciption) && string.IsNullOrEmpty(x.Name))
                {
                    context.AddFailure("jedno strzech musi byc wypelnione");
                }
            });


        }
    }
}
