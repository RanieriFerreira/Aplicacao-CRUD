using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Modelos
{
    public class Funcionario
    {
        //public Funcionario(int cpf, string nome)
        //{
        //    Cpf = cpf;
        //    Nome = nome;
        //}
        [Key]
        public int Cpf { get; set; }
        public string Nome { get; set; }
    }
}
