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
        AppDbContext _context;

        public CategoriaDAO_EfCore(AppDbContext context)
        {
            _context = context;
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias
                .Include(c => c.Leiloes);
        }
    }
}
