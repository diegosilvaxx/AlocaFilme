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
    public class FilmeController : MainController
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IFilmeService _filmeService;
        private readonly IMapper _mapper;


        public FilmeController(INotificador notificador,
                                 IMapper mapper,
                                 IFilmeRepository filmeRepository,
                                 IFilmeService filmeService,
                                 IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _filmeRepository = filmeRepository;
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeDto>>> ObterTodos()
        {
            var filmes = await _filmeRepository.ObterTodos();
            var filmesDto = _mapper.Map<IEnumerable<FilmeDto>>(filmes);
            return CustomResponse(filmesDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<FilmeDto>>> ObterPorId(Guid id)
        {
            var filme = await _filmeRepository.ObterPorId(id);
            var filmeDto = _mapper.Map<FilmeDto>(filme);

            if (filmeDto == null) return NotFound();

            return CustomResponse(filmeDto);
        }

        [HttpPost]
        public async Task<ActionResult<FilmeDto>> Adicionar(FilmeDto filmeDto)
        { 
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var filme = _mapper.Map<Filme>(filmeDto);
            await _filmeRepository.Adicionar(filme);
            return CustomResponse(filmeDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FilmeDto>> Deletar(Guid id)
        {
            await _filmeService.Remover(id);

            return CustomResponse();
        }

        [HttpDelete()]
        public async Task<ActionResult<FilmeDto>> MassRemove()
        {
            await _filmeService.MassRemove();

            return CustomResponse();
        }

    }
}
