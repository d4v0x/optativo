using FluentValidation;
using FluentValidation.Results;
using Repository.Datos;

namespace Services.Logica
{
    public class FacturaService
    {
        private readonly IFactura _facturaRepository;
        private readonly IValidator<FacturaModel> _validator;

        public FacturaService(IFactura facturaRepository, IValidator<FacturaModel> validator)
        {
            _facturaRepository = facturaRepository;
            _validator = validator;
        }

        public async Task<bool> Add(FacturaModel factura)
        {
            ValidationResult result = await _validator.ValidateAsync(factura);
            if (result.IsValid)
                return await _facturaRepository.Add(factura);
            else
                throw new ValidationException(result.Errors);
        }

        public async Task<bool> Update(FacturaModel factura)
        {
            ValidationResult result = await _validator.ValidateAsync(factura);
            if (result.IsValid)
                return await _facturaRepository.Update(factura);
            else
                throw new ValidationException(result.Errors);
        }

        public async Task<FacturaModel> Get(int id)
        {
            return await _facturaRepository.Get(id);
        }

        public async Task<List<FacturaModel>> GetAllFacturas()
        {
            return (await _facturaRepository.List()).ToList();
        }

        public async Task<bool> Delete(int id)
        {
            var factura = await _facturaRepository.Get(id);
            if (factura != null)
                return await _facturaRepository.Delete(factura);
            else
                return false;
        }
    }
}
