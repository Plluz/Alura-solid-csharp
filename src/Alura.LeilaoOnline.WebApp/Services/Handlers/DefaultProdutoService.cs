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
            return CategoriaDAO.BuscarCategoriaPorId(id);
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultarCategoriasComTotalDeLeiloesEmPregao()
        {
            return CategoriaDAO.BuscarCategorias()
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
            return LeilaoDAO.BuscarLeiloes().Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
        }
    }
}
