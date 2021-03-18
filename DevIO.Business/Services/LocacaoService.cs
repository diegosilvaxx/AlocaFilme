using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class LocacaoService : BaseService, ILocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoService(ILocacaoRepository locacaoRepository,
                              INotificador notificador) : base(notificador)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task Adicionar(Locacao locacao)
        {
            if (!ExecutarValidacao(new LocacaoValidation(), locacao)) return;

            await _locacaoRepository.Adicionar(locacao);
        }

        public async Task Atualizar(Locacao locacao)
        {
            if (!ExecutarValidacao(new LocacaoValidation(), locacao)) return;

            await _locacaoRepository.Atualizar(locacao);
        }

        public async Task Remover(Guid id)
        {
            await _locacaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _locacaoRepository?.Dispose();
        }
    }
}