using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IFilmeService : IDisposable
    {
        Task Adicionar(Filme produto);
        Task Atualizar(Filme produto);
        Task Remover(Guid id);
        Task MassRemove();
    }
}