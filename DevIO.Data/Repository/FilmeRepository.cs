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
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Filme>> GetFilmes()
        {
            return await Db.Filmes.AsNoTracking().Include(f => f.Genero)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task MassRemove()
        {
            using (var transaction = Db.Database.BeginTransaction())
            {
                try
                {
                    var filmes = await Db.Filmes.AsNoTracking().ToListAsync();

                    Db.Filmes.RemoveRange(filmes);

                    await SaveChanges();
                    transaction.Commit();
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