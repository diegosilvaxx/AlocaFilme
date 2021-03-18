using AutoMapper;
using DevIO.Api.Controllers.Common;
using DevIO.Api.DTO;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class GeneroController : MainController
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IGeneroService _generoService;
        private readonly IMapper _mapper;


        public GeneroController(INotificador notificador,
                                 IMapper mapper,
                                 IGeneroRepository generoRepository,
                                 IGeneroService generoService,
                                 IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _generoRepository = generoRepository;
            _generoService = generoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroDto>>> ObterTodos()
        {
            var generos = await _generoRepository.ObterTodos();
            var generosDto = _mapper.Map<IEnumerable<GeneroDto>>(generos);
            return CustomResponse(generosDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<GeneroDto>>> ObterPorId(Guid id)
        {
            var genero = await _generoRepository.ObterPorId(id);
            var generoDto = _mapper.Map<GeneroDto>(genero);

            if (generoDto == null) return NotFound();

            return CustomResponse(generoDto);
        }

        [HttpPost]
        public async Task<ActionResult<GeneroDto>> Adicionar(GeneroDto generoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var genero = _mapper.Map<Genero>(generoDto);
            await _generoRepository.Adicionar(genero);
            return CustomResponse(generoDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<GeneroDto>> Deletar(Guid id)
        {
            await _generoService.Remover(id);

            return CustomResponse();
        }

    }
}
