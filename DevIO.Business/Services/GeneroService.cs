using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class GeneroService : BaseService, IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository,
                              INotificador notificador) : base(notificador)
        {
            _generoRepository = generoRepository;
        }

        public async Task Adicionar(Genero genero)
        {
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return;

            await _generoRepository.Adicionar(genero);
        }

        public async Task Atualizar(Genero genero)
        {
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return;

            await _generoRepository.Atualizar(genero);
        }

        public async Task Remover(Guid id)
        {
            await _generoRepository.Remover(id);
        }

        public void Dispose()
        {
            _generoRepository?.Dispose();
        }
    }
}