using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLuisFE.Models
{
    public class Equipamento
    {
        [Key]
        public int EquipamentoId { get; set; }
        public string EquipamentoNome { get; set; }
        public string Serie { get; set; }

    }
}