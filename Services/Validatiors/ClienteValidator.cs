using FluentValidation;
using Repository.Datos;

namespace Services.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteModel>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MinimumLength(3).WithMessage("El apellido debe tener al menos 3 caracteres");

            RuleFor(x => x.Celular)
                .NotEmpty().WithMessage("El celular es obligatorio")
                .Length(10).WithMessage("El celular debe tener 10 caracteres")
                .Matches(@"^\d+$").WithMessage("El celular debe ser numérico");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("El documento es obligatorio")
                .MinimumLength(7).WithMessage("El documento debe tener al menos 7 caracteres");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio")
                .EmailAddress().WithMessage("El correo electrónico debe tener un formato válido");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("El estado es obligatorio");
        }
    }
}

