using BCOAPI.Core.Domain.Dtos;
using FluentValidation;

namespace BCOAPI.Core.Validator
{
    public class cargoValidator: AbstractValidator<cargoDto>
    {
        public cargoValidator()
        {
            RuleFor(x=>x.numeroTarjeta).NotEmpty().Length(16);
            RuleFor(x => x.monto).NotEmpty().GreaterThan(0);
            RuleFor(x => x.descripcion).NotEmpty();
            RuleFor(x=>x.fecha).NotEmpty();
        }
    }
}
