using AutoMapper;
using RelogioDePonto.Models;
using RelogioDePonto.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Empresa.Profiles
{
    public class ProfileFuncionario : Profile
    {
        public ProfileFuncionario()
        {
            CreateMap<Funcionario, ViewModelFuncionario>();
            CreateMap<ViewModelFuncionario, Funcionario>();
        }
    }
}
