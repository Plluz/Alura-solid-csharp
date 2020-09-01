using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDAO
    {
        public IEnumerable<Categoria> BuscarCategorias();

        public IEnumerable<Leilao> BuscarLeiloes();

        public Leilao BuscarPorId(int id);

        public void Inserir(Leilao leilao);

        public void Alterar(Leilao leilao);

        public void Deletar(Leilao leilao);
    }
}
