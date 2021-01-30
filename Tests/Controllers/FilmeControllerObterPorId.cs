using API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Banco.Interface;
using Negocio.Model;
using Banco.Repositorio;
using Banco.Content;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers
{
    public class FilmeControllerObterPorId
    {
        private Mock<IRepositorio<Filme>> mockRepositorio;
        private IMapper _mapper;

        public FilmeControllerObterPorId()
        {
            mockRepositorio = new Mock<IRepositorio<Filme>>();

            var config = new MapperConfiguration(c =>
                c.CreateMap<Filme, FilmeDTO>()
            );

            _mapper = new Mapper(config);
        }

        [Fact]
        public void PassadoUmIdDeveRetornarOkObjectResultDeFilme()
        {
            //Arrange

            Filme filme = new Filme()
            {
                Id = 2,
                AnoLancamento = "2009",
                Titulo = "Velozes e Furiosos",
                Descricao = "Velozes e Furiosos",
                IdIdiomaDublagem = 7
            };

            mockRepositorio.Setup(f =>
                f.ObterPorId(2)
            ).Returns(filme);

            var repositorio = mockRepositorio.Object;

            var filmeController = new FilmeController(repositorio, _mapper);

            //Act
            var retorno = filmeController.ObterPorId(2);

            //Assert
            Assert.IsType<OkObjectResult>(retorno);
        }
    }
}
