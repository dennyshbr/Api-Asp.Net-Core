using API.Model;
using API.Response;
using AutoMapper;
using Banco.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Model;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IRepositorio<Filme> _repositorio;
        private readonly IMapper _mapper;

        public FilmeController(
                    IRepositorio<Filme> repositorio,
                    IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                var filmes = _mapper.Map<IList<FilmeDTO>>(_repositorio.ListarTodos());

                return Ok(filmes);
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.From(ex));
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                Filme filme = _repositorio.ObterPorId(id);

                if (filme != null)
                {
                    var filmeDTO = _mapper.Map<FilmeDTO>(filme);

                    return Ok(filmeDTO);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.From(ex));
            }
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ErrorResponse.FromModelState(ModelState));
                }

                Filme filme = _mapper.Map<Filme>(filmeDTO);

                _repositorio.Incluir(filme);

                var uri = Url.Action("ObterPorId", new { filme.Id });

                filmeDTO.Id = filme.Id;

                return Created(uri, filmeDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.From(ex));
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ErrorResponse.FromModelState(ModelState));
                }

                Filme filme = _mapper.Map<Filme>(filmeDTO);

                _repositorio.Atualizar(filme);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.From(ex));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                Filme filme = _repositorio.ObterPorId(id);

                if (filme != null)
                {
                    _repositorio.Deletar(filme);

                    return NoContent();
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.From(ex));
            }
        }
    }
}
