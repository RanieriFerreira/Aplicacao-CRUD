using RelogioDePonto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Applications
{
    public class Application
    {
        public string BuscaTodos()
        {
            var resposta =  new FuncionarioRepositorio();
            return resposta.BuscaMock();
        }
    }
}
