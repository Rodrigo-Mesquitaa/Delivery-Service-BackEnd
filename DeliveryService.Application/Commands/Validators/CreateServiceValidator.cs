using FluentValidation;

namespace DeliveryService.Application.Commands.Validators
{
    public class CreateRouteValidator : AbstractValidator<CreateRoute>
    {
        public CreateRouteValidator()
        {

            RuleFor(a => a.Time)
                .NotEmpty()
                .WithMessage("O Tempo é obrigatório");

            RuleFor(a => a.Cost)
                .NotEmpty()
                .WithMessage("O Custo é obrigatória");

            RuleFor(a => a.ServiceOriginId)
                .NotEmpty()
                .WithMessage("A origem é obrigatória");

            RuleFor(a => a.ServiceDestinationId)
                .NotEmpty()
                .WithMessage("O destino é obrigatório");

        }
    }
}