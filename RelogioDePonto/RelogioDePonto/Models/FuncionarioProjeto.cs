using RelogioDePonto.Models;

namespace CRUD_Empresa.Models
{
    public class FuncionarioProjeto
    {
        public int FuncionarioId { get; set; }
        public int ProjetoId { get; set; }

        // Relações
        public Funcionario Funcionario { get; set; }
        public Projeto Projeto { get; set; }
    }
}
