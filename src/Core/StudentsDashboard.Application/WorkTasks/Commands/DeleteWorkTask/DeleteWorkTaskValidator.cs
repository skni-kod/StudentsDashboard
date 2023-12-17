using FluentValidation;


namespace StudentsDashboard.Application.WorkTasks.Commands.DeleteWorkTask
{
    public class DeleteWorkTaskValidator : AbstractValidator<DeleteWorkTaskCommand>
    {

        public DeleteWorkTaskValidator()
        {

            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");

        }
    }
}
