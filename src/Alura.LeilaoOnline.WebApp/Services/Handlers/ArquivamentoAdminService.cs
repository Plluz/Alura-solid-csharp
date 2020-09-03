using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class ArquivamentoAdminService : IAdminService
    {
        IAdminService DefaultService { get; }

        public ArquivamentoAdminService(ILeilaoDAO dao)
        {
            DefaultService = new DefaultAdminService(dao);
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return DefaultService.BuscarCategorias();
        }

        public Leilao BuscarLeilaoPorId(int id)
        {
            return DefaultService.BuscarLeilaoPorId(id);
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return DefaultService.BuscarLeiloes().Where(l => l.Situacao != SituacaoLeilao.Arquivado);
        }

        public void InserirLeilao(Leilao leilao)
        {
            DefaultService.InserirLeilao(leilao);
        }

        public void AlterarLeilao(Leilao leilao)
        {
            DefaultService.AlterarLeilao(leilao);
        }

        public void DeletarLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                DefaultService.AlterarLeilao(leilao);
            }
        }

        public void IniciarPregaoComId(int id)
        {
            DefaultService.IniciarPregaoComId(id);
        }

        public void FinalizarPregaoComId(int id)
        {
            DefaultService.FinalizarPregaoComId(id);
        }
    }
}
