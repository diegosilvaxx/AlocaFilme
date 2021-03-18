using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Locacao>> GetLocacao()
        {
            return await Db.Locacoes.AsNoTracking().ToListAsync();
        }

        public async Task MassRemove()
        {
            using (var transaction = Db.Database.BeginTransaction())
            {
                try
                {
                    var filmes = await Db.Generos.AsNoTracking().ToListAsync();
                    foreach (var item in filmes)
                    {
                        Db.Remove(item);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}