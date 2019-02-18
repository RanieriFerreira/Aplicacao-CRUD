using CRUD_Empresa.Models;
using CRUD_Empresa.ViewsModels;
using RelogioDePonto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Empresa.Interfaces
{
    interface IFuncionarioProjetoRepositorio : IRepositorio<FuncionarioProjeto>
    {
        IQueryable<FuncionarioProjeto> GetFuncionariosFromProjeto(int id);
        IQueryable<FuncionarioProjeto> GetProjetosFromFuncionario(int id);
    }
}
