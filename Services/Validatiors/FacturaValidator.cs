using FluentValidation;
using Repository.Datos;

namespace Services.Validators
{
    public class FacturaValidator : AbstractValidator<FacturaModel>
    {
        public FacturaValidator()
        {
            RuleFor(x => x.Nro_Factura)
                .NotEmpty().WithMessage("El número de factura es obligatorio")
                .Matches(@"^\d{3}-\d{3}-\d{6}$").WithMessage("El número de factura debe tener el formato 000-000-000000");

            RuleFor(x => x.Total)
                .GreaterThan(0).WithMessage("El total debe ser mayor que 0");

            RuleFor(x => x.Total_iva5)
                .GreaterThan(0).WithMessage("El total IVA 5% debe ser mayor que 0");

            RuleFor(x => x.Total_iva10)
                .GreaterThan(0).WithMessage("El total IVA 10% debe ser mayor que 0");

            RuleFor(x => x.Total_iva)
                .GreaterThan(0).WithMessage("El total IVA debe ser mayor que 0");

            RuleFor(x => x.Total_letras)
                .NotEmpty().WithMessage("El total en letras es obligatorio")
                .MinimumLength(6).WithMessage("El total en letras debe tener al menos 6 caracteres");
        }
    }
}

