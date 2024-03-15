using FluentValidation;


namespace StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask
{
    public class DeleteWorkTaskCommandValidator : AbstractValidator<DeleteWorkTaskCommand>
    {

        public DeleteWorkTaskCommandValidator()
        {

            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");

        }
    }
}
