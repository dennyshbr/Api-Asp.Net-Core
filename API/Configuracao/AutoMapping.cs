using API.Model;
using AutoMapper;
using Negocio.Model;

namespace API.Configuracao
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Filme, FilmeDTO>().ReverseMap();
        }
    }
}
