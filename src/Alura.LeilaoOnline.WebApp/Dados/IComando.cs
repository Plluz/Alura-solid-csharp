using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface IComando<T>
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Deletar(T obj);
    }
}
