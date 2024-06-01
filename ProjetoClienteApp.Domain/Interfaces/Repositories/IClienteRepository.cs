using ProjetoClienteApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClienteApp.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);

        public List<Cliente> GetAll();
        public Cliente? GetById(Guid id);
        public Cliente? GetByCpf(string cpf);
    }
}
