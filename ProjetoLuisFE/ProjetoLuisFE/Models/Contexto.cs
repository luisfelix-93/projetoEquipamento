using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetoLuisFE.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
    }
}