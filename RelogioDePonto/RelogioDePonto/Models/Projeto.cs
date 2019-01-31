using CRUD_Empresa.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelogioDePonto.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public int Status { get; set; }

        public IList<FuncionarioProjeto> FuncionariosProjetos { get; set; }
    }
}

