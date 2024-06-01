using ProjetoClienteApp.Domain.Entities;
using ProjetoClienteApp.Domain.Interfaces.Repositories;
using ProjetoClienteApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClienteApp.Domain.Services
{
    public class ClienteDomainService : IClienteDomainService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente AdicionarCliente(Cliente cliente)
        {
            if (_clienteRepository.GetByCpf(cliente.Cpf) != null)
            {
                throw new ApplicationException("Já existe um cliente cadastrado com este CPF.");
            }
            cliente.Id = Guid.NewGuid();
            cliente.DataHoraCadastro = DateTime.Now;
            cliente.DataHoraUltimaAtualizacao = DateTime.Now;

            _clienteRepository.Add(cliente);

            return cliente;

        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            var clienteEdicao = _clienteRepository.GetById(cliente.Id.Value);

            if (cliente == null)
            {
                throw new ApplicationException("Cliente não foi encontrado");
            }



            // Verifica se já existe algum cliente com o mesmo CPF
            var clienteComMesmoCPF = _clienteRepository.GetByCpf(cliente.Cpf);
            if (clienteComMesmoCPF != null && clienteComMesmoCPF.Id != cliente.Id)
            {
                throw new ApplicationException("Já existe um cliente com o mesmo CPF");
            }

            clienteEdicao.Nome = cliente.Nome;
            clienteEdicao.Email = cliente.Email;
            clienteEdicao.DataHoraUltimaAtualizacao = DateTime.Now;

            _clienteRepository.Update(clienteEdicao);

            return clienteEdicao;
        }

        public Cliente ExcluirCliente(Guid id)
        {
            var clienteExclusao = _clienteRepository.GetById(id);

            if (clienteExclusao != null)
            {
                _clienteRepository.Delete(clienteExclusao);
            }

            return clienteExclusao;
        }

        public List<Cliente> Consultar()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente? ObterPorId(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente != null)
                return cliente;
            else
                throw new ApplicationException("Cliente não foi encontrado");
        }

        //public Cliente? ObterPorCpf(string cpf)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
