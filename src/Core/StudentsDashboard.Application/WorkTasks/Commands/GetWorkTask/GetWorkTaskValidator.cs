
using FluentValidation;


namespace StudentsDashboard.Application.WorkTasks.Commands.GetWorkTask
{
    public class GetWorkTaskValidator : AbstractValidator<GetWorkTaskCommand>
    {

        public GetWorkTaskValidator() 
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id user is required");

            RuleFor(x => x.IdUser)
                .NotEmpty().WithMessage("Id user is required");
        }
    }
}
