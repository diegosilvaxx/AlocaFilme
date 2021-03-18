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
    public class LocacaoController : MainController
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly ILocacaoService _locacaoService;
        private readonly IMapper _mapper;


        public LocacaoController(INotificador notificador,
                                 IMapper mapper,
                                 ILocacaoRepository locacaoRepository,
                                 ILocacaoService locacaoService,
                                 IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _locacaoRepository = locacaoRepository;
            _locacaoService = locacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocacaoDto>>> ObterTodos()
        {
            var locacoes = await _locacaoRepository.ObterTodos();
            var locacoesDto = _mapper.Map<IEnumerable<LocacaoDto>>(locacoes);
            return CustomResponse(locacoesDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<LocacaoDto>>> ObterPorId(Guid id)
        {
            var locacao = await _locacaoRepository.ObterPorId(id);
            var locacaoDto = _mapper.Map<LocacaoDto>(locacao);

            if (locacaoDto == null) return NotFound();

            return CustomResponse(locacaoDto);
        }

        [HttpPost]
        public async Task<ActionResult<LocacaoDto>> Adicionar(LocacaoDto locacaoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var locacao = _mapper.Map<Locacao>(locacaoDto);
            await _locacaoRepository.Adicionar(locacao);
            return CustomResponse(locacaoDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LocacaoDto>> Deletar(Guid id)
        {
            await _locacaoService.Remover(id);

            return CustomResponse();
        }

    }
}
