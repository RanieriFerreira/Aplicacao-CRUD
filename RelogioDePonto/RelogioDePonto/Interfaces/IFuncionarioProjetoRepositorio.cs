using CRUD_Empresa.Models;
using CRUD_Empresa.ModelsInput;
using RelogioDePonto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Empresa.Interfaces
{
    interface IFuncionarioProjetoRepositorio : IRepositorio<FuncionarioProjeto>
    {
        IQueryable<OutputFuncionarioProjeto> GetFuncionariosProjeto(int id);
        IQueryable<OutputCountFuncionarioProjeto> CountFuncionariosProjeto(int id);
    }
}
