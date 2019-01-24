using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Modelos
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public int Status { get; set; }
    }
}
