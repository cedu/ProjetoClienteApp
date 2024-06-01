using AutoMapper;
using ProjetoClienteApp.Api.Models.Request;
using ProjetoClienteApp.Api.Models.Response;
using ProjetoClienteApp.Domain.Entities;

namespace ProjetoClienteApp.Api.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CriarClienteRequestModel, Cliente>();
            CreateMap<Cliente, CriarClienteResponseModel>();
            CreateMap<EditarClienteRequestModel, Cliente>();
            CreateMap<Cliente, EditarClienteResponseModel>();
            CreateMap<Cliente, ExcluirClienteResponseModel>();
            CreateMap<Cliente, ConsultarClienteResponseModel>();
        }
    }
}
