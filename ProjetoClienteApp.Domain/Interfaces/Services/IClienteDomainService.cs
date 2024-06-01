using ProjetoClienteApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClienteApp.Domain.Interfaces.Services
{
    public interface IClienteDomainService
    {
        Cliente AdicionarCliente(Cliente cliente);   
        Cliente AtualizarCliente(Cliente cliente);   
        Cliente ExcluirCliente(Guid id);

        List<Cliente> Consultar();
        Cliente? ObterPorId(Guid id);
        
        //Cliente? ObterPorCpf(string cpf);
    }
}
