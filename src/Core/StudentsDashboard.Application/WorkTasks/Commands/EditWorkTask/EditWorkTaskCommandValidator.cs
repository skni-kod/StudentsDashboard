using FluentValidation;

namespace StudentsDashboard.Application.WorkTasks.Commands.EditWorkTask
{
    public class EditWorkTaskCommandValidator : AbstractValidator<EditWorkTaskCommand>
    {
        public EditWorkTaskCommandValidator() {

            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");

             RuleFor(x => x)
            .Custom((x, context) =>
            {
                if (x.Date == null && string.IsNullOrEmpty(x.Desciption) && string.IsNullOrEmpty(x.Name))
                {
                    context.AddFailure("one of the three must be completed writen");
                }
            });


        }
    }
}
