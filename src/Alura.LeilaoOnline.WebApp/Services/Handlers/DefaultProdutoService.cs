using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultProdutoService : IProdutoService
    {
        ILeilaoDAO LeilaoDAO { get; }
        ICategoriaDAO CategoriaDAO { get; }

        public DefaultProdutoService(ILeilaoDAO leilaoDAO, ICategoriaDAO categoriaDAO)
        {
            LeilaoDAO = leilaoDAO;
            CategoriaDAO = categoriaDAO;
        }

        public Categoria ConsultarCategoriaPorIdComLeiloesEmPregao(int id)
        {
            return CategoriaDAO.BuscarPorId(id);
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultarCategoriasComTotalDeLeiloesEmPregao()
        {
            return CategoriaDAO.BuscarTodos()
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                });
        }

        public IEnumerable<Leilao> PesquisarLeiloesEmPregaoPorTermo(string termo)
        {
            var termoNormalized = termo.ToUpper();
            return LeilaoDAO.BuscarTodos().Where(l =>
                    l.Titulo.ToUpper().Contains(termoNormalized) ||
                    l.Descricao.ToUpper().Contains(termoNormalized) ||
                    l.Categoria.Descricao.ToUpper().Contains(termoNormalized));
        }
    }
}
