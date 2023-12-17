using FluentValidation;


namespace StudentsDashboard.Application.WorkTasks.Commands.GetAllWorkTask
{
    public class GetAllWorkTaskValidator : AbstractValidator<GetAllWorkTaskCommand>
    {

        public GetAllWorkTaskValidator()
        {
            RuleFor(x => x.IdUser)
            .NotEmpty().WithMessage("Id user is required");

        }
    }
}
