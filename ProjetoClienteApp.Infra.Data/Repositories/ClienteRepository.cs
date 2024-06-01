using Microsoft.EntityFrameworkCore;
using ProjetoClienteApp.Domain.Entities;
using ProjetoClienteApp.Domain.Interfaces.Repositories;
using ProjetoClienteApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClienteApp.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void Add(Cliente cliente)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Add(cliente);
                dataContext.SaveChanges();
            }
        }

        public void Update(Cliente cliente)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(cliente);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Cliente cliente)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(cliente);
                dataContext.SaveChanges();
            }
        }

        public List<Cliente> GetAll()
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Set<Cliente>().OrderByDescending(c => c.Nome).ToList(); 
            }
        }

        public Cliente? GetById(Guid id)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Set<Cliente>().Find(id);
            }
        }

        public Cliente? GetByCpf(string cpf)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Set<Cliente>().Where(c => c.Cpf == cpf).FirstOrDefault();
            }
        }
    }
}
