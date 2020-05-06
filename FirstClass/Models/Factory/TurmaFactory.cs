using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public static class TurmaFactory
    {
        public static Turma NovaTurma(string nome, int id)
        {
            return new Turma(nome, id);
        }
    }
}