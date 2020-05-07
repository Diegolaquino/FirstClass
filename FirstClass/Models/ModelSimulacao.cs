using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public class ModelSimulacao
    {
        public Materia[] Materias { get; set; }

        public decimal Peso1 { get; set; }

        public decimal Peso2 { get; set; }

        public decimal Peso3 { get; set; }

        public int NumeroAlunos { get; set; }

        public int NumeroTurmas { get; set; }
    }
}