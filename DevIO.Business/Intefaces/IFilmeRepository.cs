using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task<IEnumerable<Filme>> GetFilmes();
        Task MassRemove();
    }
}