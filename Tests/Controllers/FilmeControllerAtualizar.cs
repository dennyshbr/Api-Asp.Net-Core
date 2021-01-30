using API.Controllers;
using API.Model;
using AutoMapper;
using Banco.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Negocio.Model;
using Xunit;

namespace Tests.Controllers
{
    public class FilmeControllerAtualizar
    {
        private Mock<IRepositorio<Filme>> mockRepositorio;
        private IMapper _mapper;

        public FilmeControllerAtualizar()
        {
            mockRepositorio = new Mock<IRepositorio<Filme>>();

            var config = new MapperConfiguration(c =>
                c.CreateMap<FilmeDTO, Filme>()
            );

            _mapper = new Mapper(config);
        }

        [Fact]
        public void PassadoNovasInformacoesFilmeDeveSerAtualizado()
        {
            //Arrange
            var repositorio = mockRepositorio.Object;

            var filmeController = new FilmeController(repositorio, _mapper);

            FilmeDTO filmeDTO = new FilmeDTO()
            {
                Id = 2,
                Titulo = "Carros 2",
                Descricao = "Carros",
                IdIdiomaDublagem = 7,
                AnoLancamento = "2009"
            };

            //Act
            var retorno = filmeController.Atualizar(filmeDTO);

            //Assert
            Assert.IsType<OkResult>(retorno);
        }
    }
}
