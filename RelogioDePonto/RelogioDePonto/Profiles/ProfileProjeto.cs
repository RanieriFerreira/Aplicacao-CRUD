using AutoMapper;
using RelogioDePonto.Models;
using RelogioDePonto.ViewsModels;

namespace CRUD_Empresa.Profiles
{
    public class ProfileProjeto : Profile
    {
        public ProfileProjeto()
        {
            CreateMap<Projeto, ViewModelProjeto>();
            CreateMap<ViewModelProjeto, Projeto>();
        }
    }
}
