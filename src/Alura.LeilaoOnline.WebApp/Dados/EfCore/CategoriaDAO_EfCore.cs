using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class CategoriaDAO_EfCore : ICategoriaDAO
    {
        private AppDbContext Context { get; }

        public CategoriaDAO_EfCore(AppDbContext context)
        {
            Context = context;
        }

        public Categoria BuscarPorId(int id)
        {
            return Context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return Context.Categorias
                .Include(c => c.Leiloes);
        }
    }
}
