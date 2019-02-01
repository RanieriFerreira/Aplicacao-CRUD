using CRUD_Empresa.Models;
using CRUD_Empresa.ModelsInput;
using CRUD_Empresa.repositories;
using Microsoft.AspNetCore.Mvc;
using RelogioDePonto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Empresa.Applications
{
    public class ApplicationFuncionarioProjeto : ControllerBase
    {
        private RepositoryFuncionarioProjeto _projetoFuncionarioProjeto;
        private readonly ContextEmpresa _context;

        public ApplicationFuncionarioProjeto(ContextEmpresa context)
        {
            _projetoFuncionarioProjeto = new RepositoryFuncionarioProjeto(context);
            _context = context;
        }

        // ADD function
        // REMOVE function
        // PROCEDURES:
        //  - Get all funcionario from project id

        public FuncionarioProjeto ToFuncionarioProjeto(InputFuncionarioProjeto inputFuncionarioProjeto)
        {
            return new FuncionarioProjeto
            {
                FuncionarioId = inputFuncionarioProjeto.FuncionarioID,
                ProjetoId = inputFuncionarioProjeto.ProjetoID
            };
        }
    }
}
