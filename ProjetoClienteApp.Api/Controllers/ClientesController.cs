using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProjetoClienteApp.Api.Models.Request;
using ProjetoClienteApp.Api.Models.Response;
using ProjetoClienteApp.Domain.Entities;
using ProjetoClienteApp.Domain.Exceptions;
using ProjetoClienteApp.Domain.Interfaces.Services;

namespace ProjetoClienteApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteDomainService _clienteDomainService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteDomainService clienteDomainService, IMapper mapper)
        {
            _clienteDomainService = clienteDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarClienteResponseModel), 201)]
        public IActionResult Post(CriarClienteRequestModel model)
        {
            try
            {
                var cliente = _clienteDomainService.AdicionarCliente(_mapper.Map<Cliente>(model));

                var response = _mapper.Map<CriarClienteResponseModel>(cliente);

                return StatusCode(201, response);

            }

            catch (DomainException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(EditarClienteResponseModel), 200)]
        public IActionResult Put(EditarClienteRequestModel model)
        {
            try
            {
                var cliente = _clienteDomainService.AtualizarCliente(_mapper.Map<Cliente>(model));

                var response = _mapper.Map<EditarClienteResponseModel>(cliente);

                return StatusCode(200, response);
            }
            catch (DomainException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirClienteResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var cliente = _clienteDomainService.ExcluirCliente(id);

                var response = _mapper.Map<ExcluirClienteResponseModel>(cliente);
                response.DataHoraExclusao = DateTime.Now;

                return StatusCode(200, response);
            }
            catch (DomainException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultarClienteResponseModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var clientes = _clienteDomainService.Consultar();

                var response = _mapper.Map<List<ConsultarClienteResponseModel>>(clientes);

                return StatusCode(200, response);
            }
            catch (DomainException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var cliente = _clienteDomainService.ObterPorId(id);

                var response = _mapper.Map<ConsultarClienteResponseModel>(cliente);

                return StatusCode(200, response);
            }
            catch (DomainException e)
            {
                return StatusCode(422, new { message = "O id do cliente é inválido!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
