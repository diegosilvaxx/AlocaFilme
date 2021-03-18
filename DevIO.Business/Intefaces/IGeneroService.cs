using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IGeneroService : IDisposable
    {
        Task Adicionar(Genero produto);
        Task Atualizar(Genero produto);
        Task Remover(Guid id);
    }
}