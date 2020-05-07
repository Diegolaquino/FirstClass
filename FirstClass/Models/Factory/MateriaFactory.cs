using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public static class MateriaFactory
    {
        public static Materia NovaMateria(string nome)
        {
            return new Materia(nome);
        }
    }
}