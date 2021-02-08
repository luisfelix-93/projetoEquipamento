using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLuisFE.Models
{
    public class Funcionarios
    {
        [Key]
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Setor { get; set; }
    }
}