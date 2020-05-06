using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public static class MateriaFactory
    {
        public static Materia NovaMateria(string nome, int turmaId)
        {
            return new Materia(nome, turmaId);
        }
    }
}