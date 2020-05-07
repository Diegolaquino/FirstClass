using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public class ModelSimulacao
    {
        public Materia[] Materias { get; set; }

        public int NumeroAlunos { get; set; }

        public int NumeroTurmas { get; set; }
    }
}