using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IProdutoService
    {
        IEnumerable<Leilao> PesquisarLeiloesEmPregaoPorTermo(string termo);
        IEnumerable<CategoriaComInfoLeilao> ConsultarCategoriasComTotalDeLeiloesEmPregao();
        Categoria ConsultarCategoriaPorIdComLeiloesEmPregao(int id);
    }
}
