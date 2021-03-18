using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface ILocacaoService : IDisposable 
    {
        Task Adicionar(Locacao produto);
        Task Atualizar(Locacao produto);
        Task Remover(Guid id);
    }
}