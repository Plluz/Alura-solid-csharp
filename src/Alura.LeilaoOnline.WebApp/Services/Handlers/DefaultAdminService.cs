using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        private ILeilaoDAO DAO { get; }

        public DefaultAdminService(ILeilaoDAO dao)
        {
            DAO = dao;
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return DAO.BuscarCategorias();
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return DAO.BuscarLeiloes();
        }

        public Leilao BuscarLeilaoPorId(int id)
        {
            return DAO.BuscarPorId(id);
        }

        public void InserirLeilao(Leilao leilao)
        {
            DAO.Inserir(leilao);
        }

        public void AlterarLeilao(Leilao leilao)
        {
            DAO.Alterar(leilao);
        }

        public void DeletarLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                DAO.Deletar(leilao);
            }
        }

        public void IniciarPregaoComId(int id)
        {
            var leilao = DAO.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                DAO.Alterar(leilao);
            }
        }

        public void FinalizarPregaoComId(int id)
        {
            var leilao = DAO.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                DAO.Alterar(leilao);
            }
        }
    }
}
