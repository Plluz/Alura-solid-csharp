using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IAdminService
    {
        IEnumerable<Categoria> BuscarCategorias();
        IEnumerable<Leilao> BuscarLeiloes();
        Leilao BuscarLeilaoPorId(int id);
        void InserirLeilao(Leilao leilao);
        void AlterarLeilao(Leilao leilao);
        void DeletarLeilao(Leilao leilao);
        void IniciarPregaoComId(int id);
        void FinalizarPregaoComId(int id);
    }
}
