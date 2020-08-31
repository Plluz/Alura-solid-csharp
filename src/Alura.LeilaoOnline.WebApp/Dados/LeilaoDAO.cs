﻿using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeilaoDAO
    {
        private AppDbContext Context { get; }

        public LeilaoDAO()
        {
            Context = new AppDbContext();
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return Context.Categorias.ToList();
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return Context.Leiloes.Include(l => l.Categoria).ToList();
        }

        public Leilao BuscarPorId(int id)
        {
            return Context.Leiloes.First(l => l.Id == id);
        }

        public void Inserir(Leilao leilao)
        {
            Context.Leiloes.Add(leilao);
            Context.SaveChanges();
        }

        public void Alterar(Leilao leilao)
        {
            Context.Leiloes.Update(leilao);
            Context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            Context.Leiloes.Remove(leilao);
            Context.SaveChanges();
        }
    }
}