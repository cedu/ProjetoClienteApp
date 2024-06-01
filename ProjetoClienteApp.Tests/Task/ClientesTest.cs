using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProjetoClienteApp.Api.Models.Request;
using ProjetoClienteApp.Api.Models.Response;
using ProjetoClienteApp.Domain.Entities;
using ProjetoClienteApp.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClienteApp.Tests.Task
{
    public class ClientesTest
    {
        [Fact]
        public void CadastrarCliente_Test()
        {
            var request = CreateRequest(); //criando os dados de um cliente
            var response = CadastrarCliente(request); //cadastrando o cliente

            //verificando os dados obtidos
            response?.Id.Should().NotBeEmpty();
            response?.Nome.Should().Be(request.Nome);
            response?.Cpf.Should().Be(request.Cpf);
            response?.Email.Should().Be(request.Email);
            response?.DataHoraCadastro.Should().NotBeNull();

        }

        [Fact]
        public void EditarCliente_Test()
        {
            var request = CreateRequest(); //criando os dados de um cliente
            var cliente = CadastrarCliente(request); //cadastrando o cliente

            //atualizando a tarefa
            var result = TestHelper.CreateClient().PutAsync("/api/clientes/" + cliente.Id, TestHelper.CreateContent(request)).Result;
            var response = TestHelper.ReadResponse<EditarClienteResponseModel>(result);

            //verificando os dados obtidos
            response?.Id.Should().Be(cliente.Id);
            response?.Nome.Should().Be(cliente.Nome);
            response?.Cpf.Should().Be(cliente.Cpf);
            response?.Email.Should().Be(cliente.Email);
            response?.DataHoraUltimaAtualizacao.Should().NotBeNull();

        }

        [Fact]
        public void ExcluirCliente_Test()
        {
            var request = CreateRequest(); //criando os dados de uma tarefa
            var cliente = CadastrarCliente(request); //cadastrando a tarefa

            //excluindo a tarefa
            var result = TestHelper.CreateClient().DeleteAsync("/api/clientes/" + cliente.Id).Result;
            var response = TestHelper.ReadResponse<ExcluirClienteResponseModel>(result);

            //verificando os dados obtidos
            response?.Id.Should().Be(cliente.Id);
            response?.DataHoraExclusao.Should().NotBeNull();
        }

        [Fact]
        public void ConsultarClientes_Test()
        {
            var request = CreateRequest(); //criando os dados de um cliente
            var cliente = CadastrarCliente(request); //cadastrando o cliente

            //consultando as tarefas
            var result = TestHelper.CreateClient().GetAsync("/api/clientes/").Result;
            var response = TestHelper.ReadResponse<List<ConsultarClienteResponseModel>>(result);

            //buscando no resultado da consulta o registro da tarefa que foi cadastrada
            var cadastro = response.FirstOrDefault(c => c.Id == cliente.Id);

            //comparando os dados com o que foi cadastrado
            cadastro?.Id.Should().Be(cliente.Id);
            cadastro?.Nome.Should().Be(cliente.Nome);
            cadastro?.Cpf.Should().Be(cliente.Cpf);
            cadastro?.Email.Should().Be(cliente.Email);
            cadastro?.DataHoraCadastro.Should().NotBeNull();

        }

        [Fact]
        public void ObterClientePorId_Test()
        {
            var request = CreateRequest(); //criando os dados de um cliente
            var cliente = CadastrarCliente(request); //cadastrando o cliente

            //consultando o cliente pelo id
            var result = TestHelper.CreateClient().GetAsync("/api/clientes/" + cliente.Id).Result;
            var response = TestHelper.ReadResponse<ConsultarClienteResponseModel>(result);

            //verificando os dados obtidos
            response?.Id.Should().Be(cliente.Id);
            response?.Nome.Should().Be(cliente.Nome);
            response?.Cpf.Should().Be(cliente.Cpf);
            response?.Email.Should().Be(cliente.Email);
            response?.DataHoraCadastro.Should().NotBeNull();

        }

        /// <summary>
        /// Método auxilizar para criar os dados de requisição para uma cliente
        /// </summary>
        private CriarClienteRequestModel CreateRequest()
        {
            var faker = new Faker("pt_BR");
            var request = new CriarClienteRequestModel
            {
                Nome = faker.Person.FullName, // Corrigido para gerar uma frase única
                Cpf = faker.Random.Replace("###.###.###-##"),
                Email = faker.Internet.Email()
            };

            return request;
        }

        /// <summary>
        /// Método auxilizar para cadastrar um cliente na API
        /// </summary>
        private CriarClienteResponseModel CadastrarCliente(CriarClienteRequestModel request)
        {
            var result = TestHelper.CreateClient().PostAsync("/api/clientes", TestHelper.CreateContent(request)).Result;
            return TestHelper.ReadResponse<CriarClienteResponseModel>(result);
        }

    }
}
