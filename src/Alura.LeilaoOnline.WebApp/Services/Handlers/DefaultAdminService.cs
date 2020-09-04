using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Dados.EfCore;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        private ILeilaoDAO LeilaoDAO { get; }
        private ICategoriaDAO CategoriaDAO { get; }

        public DefaultAdminService(ILeilaoDAO leilaoDAO, ICategoriaDAO categoriaDAO)
        {
            LeilaoDAO = leilaoDAO;
            CategoriaDAO = categoriaDAO;
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return CategoriaDAO.BuscarTodos();
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return LeilaoDAO.BuscarTodos();
        }

        public Leilao BuscarLeilaoPorId(int id)
        {
            return LeilaoDAO.BuscarPorId(id);
        }

        public void InserirLeilao(Leilao leilao)
        {
            LeilaoDAO.Inserir(leilao);
        }

        public void AlterarLeilao(Leilao leilao)
        {
            LeilaoDAO.Alterar(leilao);
        }

        public void DeletarLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                LeilaoDAO.Deletar(leilao);
            }
        }

        public void IniciarPregaoComId(int id)
        {
            var leilao = LeilaoDAO.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                LeilaoDAO.Alterar(leilao);
            }
        }

        public void FinalizarPregaoComId(int id)
        {
            var leilao = LeilaoDAO.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                LeilaoDAO.Alterar(leilao);
            }
        }
    }
}
