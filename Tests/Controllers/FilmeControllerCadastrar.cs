using API.Controllers;
using API.Model;
using AutoMapper;
using Banco.Content;
using Banco.Interface;
using Banco.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Negocio.Model;
using Xunit;

namespace Tests.Controllers
{
    public class FilmeControllerCadastrar
    {
        private IRepositorio<Filme> _repositorio;
        private Mock<IUrlHelper> _urlHelper;
        private IMapper _mapper;

        public FilmeControllerCadastrar()
        {
            //Fake
            var options = new DbContextOptionsBuilder<FilmeDBContext>()
                                .UseInMemoryDatabase("FilmeDBContext")
                                .Options;

            var contexto = new FilmeDBContext(options);

            _repositorio = new RepositorioEF<Filme>(contexto);

            _urlHelper = new Mock<IUrlHelper>(MockBehavior.Strict);

            var config = new MapperConfiguration(c =>
                c.CreateMap<FilmeDTO, Filme>()
            );

            _mapper = new Mapper(config);
        }

        [Fact]
        public void DadoInfoValidasDeveRetornarCreatedResult()
        {
            //Arrange

            FilmeDTO filmeDTO = new FilmeDTO()
            {
                Titulo = "Velozes e Furiosos",
                Descricao = "Velozes e Furiosos",
                AnoLancamento = "2009",
                IdIdiomaDublagem = 7
            };

            var filmeController = new FilmeController(_repositorio, _mapper);

            _urlHelper.Setup(
                    x => x.Action(It.IsAny<UrlActionContext>())
            ).Returns("test");

            filmeController.Url = _urlHelper.Object;

            //Act
            var retorno = filmeController.Cadastrar(filmeDTO);

            //Assert
            Assert.IsType<CreatedResult>(retorno);
        }
    }
}
