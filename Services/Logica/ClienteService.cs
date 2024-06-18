using FluentValidation;
using FluentValidation.Results;
using Repository.Datos;

namespace Services.Logica
{
    public class ClienteService
    {
        private readonly ICliente _clienteRepository;
        private readonly IValidator<ClienteModel> _validator;

        public ClienteService(ICliente clienteRepository, IValidator<ClienteModel> validator)
        {
            _clienteRepository = clienteRepository;
            _validator = validator;
        }

        public async Task<bool> Add(ClienteModel cliente)
        {
            ValidationResult result = await _validator.ValidateAsync(cliente);
            if (result.IsValid)
                return await _clienteRepository.Add(cliente);
            else
                throw new ValidationException(result.Errors);
        }

        public async Task<bool> Update(ClienteModel cliente)
        {
            ValidationResult result = await _validator.ValidateAsync(cliente);
            if (result.IsValid)
                return await _clienteRepository.Update(cliente);
            else
                throw new ValidationException(result.Errors);
        }

        public async Task<ClienteModel> Get(int id)
        {
            var cliente = await _clienteRepository.Get(id);
            if (cliente.Estado == "Activo")
            {
                return cliente;
            }
            throw new Exception("El cliente no está activo");
        }

        public async Task<List<ClienteModel>> GetAllClientes()
        {
            var clientes = (await _clienteRepository.List()).Where(c => c.Estado == "Activo").ToList();
            return clientes;
        }

        public async Task<bool> Delete(int id)
        {
            var cliente = await _clienteRepository.Get(id);
            if (cliente != null)
                return await _clienteRepository.Delete(cliente);
            else
                return false;
        }
    }
}
