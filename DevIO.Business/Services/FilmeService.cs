using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class FilmeService : BaseService, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository,
                              INotificador notificador) : base(notificador)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task Adicionar(Filme filme)
        {
            if (!ExecutarValidacao(new FilmeValidation(), filme)) return;

            await _filmeRepository.Adicionar(filme);
        }

        public async Task Atualizar(Filme filme)
        {
            if (!ExecutarValidacao(new FilmeValidation(), filme)) return;

            await _filmeRepository.Atualizar(filme);
        }

        public async Task Remover(Guid id)
        {
            await _filmeRepository.Remover(id);
        }

        public async Task MassRemove()
        {
            await _filmeRepository.MassRemove();
        }


        public void Dispose()
        {
            _filmeRepository?.Dispose();
        }
    }
}