using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLuisFE.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int FuncionarioId { get; set; }
        public int EquipamentoId { get; set; }

        public virtual string Nome { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string Setor { get; set; }
        public virtual string EquipamentoNome { get; set; }
    }
}