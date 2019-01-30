using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Models
{
    public class Funcionario
    {
       [Key]
       public int Id { get; set; }
       public int Cpf { get; set; }
       public string Nome { get; set; }
       public int Status { get; set; }
    }
}
