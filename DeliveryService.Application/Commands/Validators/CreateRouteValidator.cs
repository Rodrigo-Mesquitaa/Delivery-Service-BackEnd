using FluentValidation;

namespace DeliveryService.Application.Commands.Validators
{
    public class CreateServiceValidator :
    AbstractValidator<CreateService>
    {
        public CreateServiceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório");


        }
    }
}